using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.Models.Booking;
using App.Repositories.Cms.AppointRule;
using App.Repositories.Cms.Person;
using App.Repositories.Cms.PersonBooking;
using App.ViewModels.Booking;
using App.ViewModels.MyBookings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Options = App.cms.Options.Options;

namespace App.Controllers.Booking
{
    public class MyBookingsController : CommonController
    {
        private readonly IBookingHistoryCookieRepository _bookingHistoryCookieRepository;
        private readonly IPersonBookingRepository _personBookingRepository;
        private readonly ILocalOptionsCookieRepository _localOptionsCookieRepository;
        private readonly IPersonRepository _personRepository;

        public MyBookingsController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository,
            IBookingHistoryCookieRepository bookingHistoryCookieRepository, 
            IPersonBookingRepository personBookingRepository,
            ILocalOptionsCookieRepository localOptionsCookieRepository,
            IPersonRepository personRepository) : base(languageCookieRepository)
        {
            _bookingHistoryCookieRepository = bookingHistoryCookieRepository;
            _personBookingRepository = personBookingRepository;
            _localOptionsCookieRepository = localOptionsCookieRepository;
            _personRepository = personRepository;
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var historyIds = _bookingHistoryCookieRepository.GetValue().BookingIds;

            var bookings = await _personBookingRepository.GetAll().Where(w => historyIds.Contains(w.Id))
                .Include(w => w.PersonModel)
                .Include(w => w.AppointTimeModels)
                .ToListAsync();
             
            var myBookings = new MyBookingsPageViewModel()
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.MyBookings),
                FooterViewModel = await GetFooterViewModel(),
                MyBookings = bookings.Select(w=> new PersonBookingDto(w)).ToList(),
            };
            
            return View(myBookings);
        }
    }
}