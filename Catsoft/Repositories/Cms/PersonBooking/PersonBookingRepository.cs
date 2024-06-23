using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms;
using App.cms.Repositories;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.Models;
using App.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Cms.PersonBooking
{
    public class PersonBookingRepository(
        CatsoftContext catsoftContext,
        TextResourceRepository textResourceRepository,
        CmsOptions cmsOptions)
        : CmsBaseRepository<PersonBookingModel, CatsoftContext>(catsoftContext), IPersonBookingRepository
    {
        private readonly CatsoftContext _catsoftContext = catsoftContext;
        private readonly CmsOptions _cmsOptions = cmsOptions;
        private readonly TextResourceRepository _textResourceRepository = textResourceRepository;

        public async Task<PersonBookingModel> GetDefault(Guid? uuid = null)
        {
            var result = await _catsoftContext.PersonBookings.FirstOrDefaultAsync(w => w.Id == uuid);
            if (result == null)
            {
                result = new PersonBookingModel();
                _catsoftContext.Add(result);
                await _catsoftContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task ToggleTime(Guid bookingUuid, Guid appointTimeUuid)
        {
            await DoWithUpdate(bookingUuid, w =>
            {
                if (!w.SelectedTimes.Add(appointTimeUuid))
                {
                    w.SelectedTimes.Remove(appointTimeUuid);
                }

                return Task.CompletedTask;
            });
        }

        public async Task UpdateIp(Guid bookingUuid, string ip)
        {
            await DoWithUpdate(bookingUuid, w =>
            {
                w.Ip = ip;
                return Task.CompletedTask;
            });
        }

        public async Task SelectPeopleCount(Guid bookingUuid, int peopleCount)
        {
            await DoWithUpdate(bookingUuid, w =>
            {
                w.PeopleCount = peopleCount;
                return Task.CompletedTask;
            });
        }

        public Task<PersonBookingModel> StartOrUpdatePrePriceStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking => { booking.BookingStage = BookingStage.PrePrice; });
        }


        public Task<PersonBookingModel> StartOrUpdateBookingStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking => { booking.BookingStage = BookingStage.TimeSelection; });
        }

        public Task<PersonBookingModel> StartPersonDetailsStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking => { booking.BookingStage = BookingStage.PersonalDetails; });
        }

        public Task<PersonBookingModel> StartConfirmationStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking => { booking.BookingStage = BookingStage.Confirmation; });
        }

        public Task<PersonBookingModel> Block(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking =>
            {
                var selectedTimes = await catsoftContext.AppointTimes.Where(w => booking.SelectedTimes.Contains(w.Id))
                    .ToListAsync();

                foreach (var appointTimeModel in selectedTimes)
                {
                    appointTimeModel.PersonBookingId = booking.Id;
                    appointTimeModel.Blocked = true;
                    catsoftContext.AppointTimes.Update(appointTimeModel);
                }

                booking.FinalPrice = (double)selectedTimes.Sum(w => w.Price) * booking.PeopleCount;
            });
        }

        public async Task<PersonBookingModel> Book(Guid? uuid, Guid personData)
        {
            var result = await DoWithUpdate(uuid, async booking =>
            {
                booking.BookingStage = BookingStage.Success;
                booking.PersonModelId = personData;

                var selectedTimes = await catsoftContext.AppointTimes.Where(w => booking.SelectedTimes.Contains(w.Id))
                    .ToListAsync();

                foreach (var appointTimeModel in selectedTimes)
                {
                    appointTimeModel.Booked = true;
                    catsoftContext.AppointTimes.Update(appointTimeModel);
                }
            });
            await SendBookEmail(result);

            return result;
        }

        public Task<PersonBookingModel> Pay(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking =>
            {
                booking.Paid = true;

                var selectedTimes = await catsoftContext.AppointTimes.Where(w => booking.SelectedTimes.Contains(w.Id))
                    .ToListAsync();

                foreach (var appointTimeModel in selectedTimes)
                {
                    appointTimeModel.Paid = true;
                    catsoftContext.AppointTimes.Update(appointTimeModel);
                }
            });
        }

        private async Task SendBookEmail(PersonBookingModel booking)
        {
            var contactsModel =
                await CatsoftContext.ContactsModels.FirstOrDefaultAsync(w => w.ContactType == ContactType.Email);

            var fullModel = await CatsoftContext.PersonBookings.Include(w => w.AppointTimeModels)
                .Include(w => w.PersonModel)
                .FirstOrDefaultAsync(w => w.Id == booking.Id);

            var bookingInfo = fullModel.ToString();

            var contactsInfoText = await _textResourceRepository.GetByTagAsync("Booking information");
            var newOrderText = await _textResourceRepository.GetByTagAsync("New booking");

            var text = $"{contactsInfoText} : {bookingInfo}\n";

            EmailService.Send(new EmailModel
            {
                From = contactsModel.Link,
                To = contactsModel.Link,
                Subject = newOrderText,
                Body = text
            }, _cmsOptions);
        }
    }
}