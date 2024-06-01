using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.Models.Booking;
using App.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Options = App.cms.Options.Options;

namespace App.Controllers.Booking
{
    public class BookingController : CommonController
    {
        public BookingController(CatsoftContext dbContext)
        {
            base.DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var endDate = DateOnly.FromDateTime((DateTime.Now + Options.BookingAvailableRange));

            var times = await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToListAsync();
            
            var model = new BookingPageViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                AvailableAppointTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                RentPlaces = await DbContext.RentPlaces.Select(w => new RentPlaceDto(w)).ToListAsync(),
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
    }
}