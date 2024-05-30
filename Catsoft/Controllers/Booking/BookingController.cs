using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
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

        [HttpPost]
        public async Task<IActionResult> SelectAppointTime(Guid uuid)
        {
            var selection = CookieHelper.GetBookingSelection(HttpContext);
            if (!selection.SelectedAppointTimeIds.Add(uuid))
            {
                selection.SelectedAppointTimeIds.Remove(uuid);
            }

            CookieHelper.SaveBookingSelection(HttpContext, selection);

            return await ValidateSelection();
        }

        [HttpPost]
        public async Task<IActionResult> SetPersonCount(int personCount)
        {
            var selection = CookieHelper.GetBookingSelection(HttpContext);
            selection.PeopleCount = personCount;           
            CookieHelper.SaveBookingSelection(HttpContext, selection);

            return await ValidateSelection();
        }

        private async Task<IActionResult> ValidateSelection()
        {
            //todo
            return RedirectToAction("Index");
        }
        
        
        private List<AppointTimeDto> GetAvailableAppointTimes()
        {
            return CatsoftContext.AppointTimes.Where(w => !w.Booked && !w.Blocked).Select(w => new AppointTimeDto(w)).ToList();
        }
    }
}