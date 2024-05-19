using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;
using Options = App.cms.Options.Options;

namespace App.Controllers.Booking
{
    public class BookingController : CommonController
    {
        public BookingController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new BookingPageViewModel
            {
                HeaderViewModel = GetHeaderViewModel(Menu.Booking),
                FooterViewModel = GetFooterViewModel(),
                AvailableAppointTimes = GetAvailableAppointTimes(),
                RentPlaces = CatsoftContext.RentPlaces.Select(w => new RentPlaceDto(w)).ToList(),
            };

            return View(model);
        }


        private List<AppointTimeDto> GetAvailableAppointTimes()
        {
            return CatsoftContext.AppointTimes.Where(w => !w.Booked && !w.Blocked).Select(w => new AppointTimeDto(w)).ToList();
        }
    }
}