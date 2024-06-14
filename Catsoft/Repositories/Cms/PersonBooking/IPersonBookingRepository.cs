using System;
using System.Threading.Tasks;
using App.cms.Repositories;
using App.Models.Booking;

namespace App.Repositories.Cms.PersonBooking
{
    public interface IPersonBookingRepository : ICmsBaseRepository<PersonBookingModel>
    {
        public Task<PersonBookingModel> StartOrUpdatePrePriceStage(Guid? uuid);

        public Task<PersonBookingModel> StartOrUpdateBookingStage(Guid? uuid);

        public Task ToggleTime(Guid bookingUuid, Guid appointTimeUuid);
        
        public Task SelectPeopleCount(Guid bookingUuid, int peopleCount);

        public Task<PersonBookingModel> StartPersonDetailsStage(Guid? uuid);

        public Task<PersonBookingModel> StartConfirmationStage(Guid? uuid);

        public Task<PersonBookingModel> Book(Guid? uuid);
    }
}