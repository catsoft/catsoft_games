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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Options = App.cms.Options.Options;

namespace App.Controllers.Booking
{
    public class BookingController : CommonController
    {
        private readonly IBookingHistoryCookieRepository _bookingHistoryCookieRepository;
        private readonly IAppointRuleRepository _appointRuleRepository;
        private readonly IPersonBookingRepository _personBookingRepository;
        private readonly ILocalOptionsCookieRepository _localOptionsCookieRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IBookingSelectionCookieRepository _bookingSelectionCookieRepository;

        public BookingController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository,
            IBookingSelectionCookieRepository bookingSelectionCookieRepository,
            IBookingHistoryCookieRepository bookingHistoryCookieRepository, 
            IAppointRuleRepository appointRuleRepository,
            IPersonBookingRepository personBookingRepository,
            ILocalOptionsCookieRepository localOptionsCookieRepository,
            IPersonRepository personRepository) : base(languageCookieRepository)
        {
            _bookingSelectionCookieRepository = bookingSelectionCookieRepository;
            _bookingHistoryCookieRepository = bookingHistoryCookieRepository;
            _appointRuleRepository = appointRuleRepository;
            _personBookingRepository = personBookingRepository;
            _localOptionsCookieRepository = localOptionsCookieRepository;
            _personRepository = personRepository;
            DbContext = dbContext;
        }

        #region PrePrice

        public async Task<IActionResult> GetPrePrice()
        {
            var selection = _bookingSelectionCookieRepository.GetValue();
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartOrUpdatePrePriceStage);
            
            var prePrice = await _appointRuleRepository.PriceForTheDate(selection.Date);

            return View(prePrice * booking.PeopleCount);
        }

        #endregion


        #region Booking selection

        public async Task<IActionResult> Index()
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartOrUpdateBookingStage);

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var endDate = DateOnly.FromDateTime(DateTime.Now + Options.BookingAvailableRange);

            var times = await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToListAsync();

            var model = new BookingPageViewModel
            {
                PersonBookingDto = new PersonBookingDto(booking),
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
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            await _personBookingRepository.ToggleTime(booking.Id, uuid);
   
            return await ValidateSelection();
        }

        [HttpPost]
        public async Task<IActionResult> SetPersonCount(int personCount)
        {
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            await _personBookingRepository.SelectPeopleCount(booking.Id, personCount);

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
        
        public async Task<IActionResult> GetSelectedTimes()
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }
        
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var endDate = DateOnly.FromDateTime(DateTime.Now + Options.BookingAvailableRange);
            
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
        
            var times = await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToListAsync();
        
            var model = new BookingPageViewModel
            {
                PersonBookingDto = new PersonBookingDto(booking),
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                AvailableAppointTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                RentPlaces = await DbContext.RentPlaces.Select(w => new RentPlaceDto(w)).ToListAsync()
            };
        
            return View(model);
        }
        
        #endregion


        #region ContactData

        [HttpGet]
        public async Task<IActionResult> EnterPersonDetails()
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartPersonDetailsStage);
            var person = await _bookingSelectionCookieRepository.GetWithUpdate(_personRepository.GetDefault);
            
            var times = await GetSelectedTimesDtos();

            var model = new PersonDetailsViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                PersonBookingDto = new PersonBookingDto(booking),
                PersonDto = new PersonDto(person)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EnterPersonDetails(EnterPersonDetailsViewModel input)
        {
            var model = await _bookingSelectionCookieRepository.GetWithUpdate(_personRepository.GetDefault);
            if (model.Id != input.Id)
            {
                throw new Exception("Something went wrong");
            }

            model.NIF = input.NIF;
            model.Comment = input.Comment;
            model.Phone = input.Phone;
            model.Email = input.Email;
            model.CompanyAddress = input.CompanyAddress;
            model.CompanyName = input.CompanyName;
            model.CompanyNIF = input.CompanyNIF;
            model.FullName = input.FullName;
            model.IsCompany = input.IsCompany == "on";
            
            await _personRepository.UpdateAsync(model);

            var selection = _bookingSelectionCookieRepository.GetValue();

            var booking = new PersonBookingModel
            {
                PersonModelId = model.Id,
                Paid = false,
                Booked = false,
            };
            DbContext.PersonBookings.Add(booking);
            await DbContext.SaveChangesAsync();

            selection.BookingId = booking.Id.ToString();

            var selectedTimes = GetSelectedTimesDtos();
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
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartPersonDetailsStage);
            var person = await _bookingSelectionCookieRepository.GetWithUpdate(_personRepository.GetDefault);
            
            var times = await GetBookingTimes(booking.Id);
            
            var model = new BookingConfirmationViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                PersonBookingDto = new PersonBookingDto(booking),
                PersonDto = new PersonDto(person)
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookingConfirmation(string uuid)
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
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

        
        #region Success

        public async Task<IActionResult> BookingSuccess()
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }
            
            var bookingHistory = _bookingHistoryCookieRepository.GetValue();
            var lastBookingId = Guid.Parse(bookingHistory.BookingId.Last());
            var times = await DbContext.AppointTimes.Where(w => w.PersonBookingId == lastBookingId).ToListAsync();
            var personBooking = await _personBookingRepository.GetDefault(lastBookingId);

            var model = new BookingSuccessViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                PersonBookingDto = new PersonBookingDto(personBooking),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList()
            };

            return View(model);
        }

        #endregion
        
        

        #region Selection validation

        private async Task<IActionResult> ValidateSelection()
        {
            //todo
            return Ok();
        }

        private async Task<List<AppointTimeModel>> GetSelectedTimesDtos()
        {
            var selection = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            return await DbContext.AppointTimes.Where(w => !w.Booked && !w.Blocked)
                .Where(w => selection.SelectedTimes.Contains(w.Id))
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