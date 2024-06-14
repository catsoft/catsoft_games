﻿using System;
using System.Threading.Tasks;
using App.cms.Repositories;
using App.Models;
using App.Models.Booking;

namespace App.Repositories.Cms.PersonBooking
{
    public class PersonBookingRepository(CatsoftContext catsoftContext)
        : CmsBaseRepository<PersonBookingModel, CatsoftContext>(catsoftContext), IPersonBookingRepository
    {
        private readonly CatsoftContext _catsoftContext = catsoftContext;

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
            return DoWithUpdate(uuid, async booking=>
            {
                booking.BookingStage = BookingStage.PrePrice;
            });
        }
        
        public Task<PersonBookingModel> StartOrUpdateBookingStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking=>
            {
                booking.BookingStage = BookingStage.TimeSelection;
            });
        }
        
        public Task<PersonBookingModel> StartPersonDetailsStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking=>
            {
                booking.BookingStage = BookingStage.PersonalDetails;
            });
        }
        
        public Task<PersonBookingModel> StartConfirmationStage(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking=>
            {
                booking.BookingStage = BookingStage.Confirmation;
            });
        }

        public Task<PersonBookingModel> Book(Guid? uuid)
        {
            return DoWithUpdate(uuid, async booking=>
            {
                booking.BookingStage = BookingStage.Success;
            });
        }
    }
}