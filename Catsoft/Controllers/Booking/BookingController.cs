using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.cms.StaticHelpers.Cookies.models;
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
        private readonly IBookingHistoryCookieRepository _bookingHistoryCookieRepository;
        private readonly IBookingSelectionCookieRepository _bookingSelectionCookieRepository;
        private readonly IPersonDetailsCookieRepository _personDetailsCookieRepository;

        public BookingController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository,
            IBookingSelectionCookieRepository bookingSelectionCookieRepository,
            IPersonDetailsCookieRepository personDetailsCookieRepository,
            IBookingHistoryCookieRepository bookingHistoryCookieRepository) : base(languageCookieRepository)
        {
            _bookingSelectionCookieRepository = bookingSelectionCookieRepository;
            _personDetailsCookieRepository = personDetailsCookieRepository;
            _bookingHistoryCookieRepository = bookingHistoryCookieRepository;
            DbContext = dbContext;
        }


        #region Success

        public async Task<IActionResult> BookingSuccess()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var bookingHistory = _bookingHistoryCookieRepository.GetValue();
            var lastBookingId = Guid.Parse(bookingHistory.BookingId.Last());
            var times = await DbContext.AppointTimes.Where(w => w.PersonBookingId == lastBookingId).ToListAsync();
            var personBooking = await DbContext.PersonBookings.FirstOrDefaultAsync(w => w.Id == lastBookingId);

            var model = new BookingSuccessViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                PersonBooking = new PersonBookingDto(personBooking),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList()
            };

            return View(model);
        }

        #endregion


        #region Booking selection

        public async Task<IActionResult> Index()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var endDate = DateOnly.FromDateTime(DateTime.Now + Options.BookingAvailableRange);

            var times = await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToListAsync();

            var model = new BookingPageViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                AvailableAppointTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                RentPlaces = await DbContext.RentPlaces.Select(w => new RentPlaceDto(w)).ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SelectAppointTime(Guid uuid)
        {
            var selection = _bookingSelectionCookieRepository.GetValue();
            if (!selection.SelectedAppointTimeIds.Add(uuid))
            {
                selection.SelectedAppointTimeIds.Remove(uuid);
            }

            _bookingSelectionCookieRepository.SaveValue(selection);

            return await ValidateSelection();
        }

        [HttpPost]
        public async Task<IActionResult> SetPersonCount(int personCount)
        {
            var selection = _bookingSelectionCookieRepository.GetValue();
            selection.PeopleCount = personCount;
            _bookingSelectionCookieRepository.SaveValue(selection);

            return await ValidateSelection();
        }

        [HttpPost]
        public async Task<IActionResult> SetDate(DateOnly date)
        {
            var selection = _bookingSelectionCookieRepository.GetValue();
            selection.Date = date;
            _bookingSelectionCookieRepository.SaveValue(selection);

            return await ValidateSelection();
        }
        
        #endregion


        #region ContactData

        [HttpGet]
        public async Task<IActionResult> EnterPersonDetails()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var times = await GetSelectedTimes();

            var model = new PersonDetailsViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EnterPersonDetails(PersonModel model)
        {
            DbContext.PersonModels.Add(model);
            await DbContext.SaveChangesAsync();

            _personDetailsCookieRepository.SaveValue(new PersonDetailsCookieDto(model));

            var selection = _bookingSelectionCookieRepository.GetValue();

            var booking = new PersonBookingModel
            {
                PersonModelId = model.Id,
                Paid = false,
                Booked = false,
                Instant = false
            };
            DbContext.PersonBookings.Add(booking);
            await DbContext.SaveChangesAsync();

            selection.BookingId = booking.Id.ToString();

            var selectedTimes = GetSelectedTimes();
            foreach (var appointTimeModel in selectedTimes.Result)
            {
                appointTimeModel.PersonBookingId = booking.Id;
                appointTimeModel.Blocked = true;
                DbContext.AppointTimes.Update(appointTimeModel);
            }

            await DbContext.SaveChangesAsync();

            return RedirectToAction("BookingConfirmation");
        }

        #endregion


        #region Confirmation

        [HttpGet]
        public async Task<IActionResult> BookingConfirmation()
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var selection = _bookingSelectionCookieRepository.GetValue();
            var bookingId = selection.GetBookingGuid();
            var times = await GetBookingTimes(bookingId);

            var model = new BookingConfirmationViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookingConfirmation(string uuid)
        {
            if (!Options.IsBookingEnabled)
            {
                return RedirectToAction("Index", "Home");
            }

            var bookingId = Guid.Parse(uuid);
            var booking = await DbContext.PersonBookings.FirstOrDefaultAsync(w => w.Id == bookingId);
            booking.Booked = true;
            DbContext.PersonBookings.Update(booking);

            var times = await GetBookingTimes(bookingId);
            foreach (var time in times)
            {
                time.Booked = true;
                DbContext.AppointTimes.Update(time);
            }

            await DbContext.SaveChangesAsync();

            // last price for booking

            var history = _bookingHistoryCookieRepository.GetValue();
            history.BookingId.Add(uuid);
            _bookingHistoryCookieRepository.SaveValue(history);

            _bookingSelectionCookieRepository.Clear();

            return RedirectToAction("BookingSuccess");
        }

        #endregion


        #region Selection validation

        private async Task<IActionResult> ValidateSelection()
        {
            //todo
            return RedirectToAction("Index");
        }

        private async Task<List<AppointTimeModel>> GetSelectedTimes()
        {
            var selection = _bookingSelectionCookieRepository.GetValue();
            return await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => selection.SelectedAppointTimeIds.Contains(w.Id))
                .ToListAsync();
        }

        private async Task<List<AppointTimeModel>> GetBookingTimes(Guid bookingId)
        {
            return await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => w.PersonBookingId == bookingId)
                .ToListAsync();
        }

        #endregion
    }
}