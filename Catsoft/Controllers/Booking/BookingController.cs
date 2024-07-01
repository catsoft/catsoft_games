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
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartOrUpdatePrePriceStage);
            
            var prePrice = await _appointRuleRepository.PriceForTheDate(booking.Date);

            return View(prePrice * booking.PeopleCount);
        }

        #endregion
        
        
        #region Current Price

        public async Task<IActionResult> GetCurrentPrice()
        {
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            var ids = booking.SelectedTimes;

            var times = await DbContext.AppointTimes.Where(w => ids.Contains(w.Id))
                .ToListAsync();

            var sum = times.Sum(w => w.Price);
            var result = sum * booking.PeopleCount;

            return View((double)result);
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
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
            await _personBookingRepository.UpdateIp(booking.Id, ip);

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
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            await _personBookingRepository.DoWithUpdate(booking.Id, w =>
            {
                w.Date = date;
                return Task.CompletedTask;
            });

            return await ValidateSelection();
        }
        
        public async Task<IActionResult> GetSelectedTimes()
        {
            if (!_localOptionsCookieRepository.BookingEnabled())
            {
                return RedirectToAction("Index", "Home");
            }
        
            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);

            var times = await GetSelectedTimesDtos();
        
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
            var personModel = await _bookingSelectionCookieRepository.GetWithUpdate(_personRepository.GetDefault);
            if (personModel.Id != input.Id)
            {
                throw new Exception("Something went wrong");
            }

            personModel.NIF = input.NIF;
            personModel.Comment = input.Comment;
            personModel.Phone = input.Phone;
            personModel.Email = input.Email;
            personModel.CompanyAddress = input.CompanyAddress;
            personModel.CompanyName = input.CompanyName;
            personModel.CompanyNIF = input.CompanyNIF;
            personModel.FullName = input.FullName;
            personModel.IsCompany = input.IsCompany == "on";
            
            await _personRepository.UpdateAsync(personModel);

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            await _personBookingRepository.Block(booking.Id);

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

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.StartConfirmationStage);
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

            var booking = await _bookingSelectionCookieRepository.GetWithUpdate(_personBookingRepository.GetDefault);
            var person = await _bookingSelectionCookieRepository.GetWithUpdate(_personRepository.GetDefault);
            await _personBookingRepository.Book(booking.Id, person.Id);

            var history = _bookingHistoryCookieRepository.GetValue();
            history.BookingIds.Add(Guid.Parse(uuid));
            _bookingHistoryCookieRepository.SaveValue(history);

            var selection = _bookingSelectionCookieRepository.GetValue();
            selection.BookingId = null;
            _bookingSelectionCookieRepository.SaveValue(selection);

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
            var lastBookingId = bookingHistory.BookingIds.Last();
            var times = await DbContext.AppointTimes.Where(w => w.PersonBookingId == lastBookingId).ToListAsync();
            var personBooking = await _personBookingRepository.GetDefault(lastBookingId);
            var person = await _personRepository.GetDefault(personBooking.PersonModelId);

            var model = new BookingSuccessViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
                FooterViewModel = await GetFooterViewModel(),
                PersonBookingDto = new PersonBookingDto(personBooking),
                SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
                PersonDto = new PersonDto(person)
            };

            return View(model);
        }

        #endregion


        #region Parts   
        //
        // [HttpGet]
        // public async Task<IActionResult> Summary()
        // {
        //     var bookingHistory = _bookingHistoryCookieRepository.GetValue();
        //     var lastBookingId = bookingHistory.BookingIds.Last();
        //     var times = await DbContext.AppointTimes.Where(w => w.PersonBookingId == lastBookingId).ToListAsync();
        //     var personBooking = await _personBookingRepository.GetDefault(lastBookingId);
        //     var person = await _personRepository.GetDefault(personBooking.PersonModelId);
        //
        //     var model = new BookingSuccessViewModel
        //     {
        //         HeaderViewModel = await GetHeaderViewModel(Menu.Booking),
        //         FooterViewModel = await GetFooterViewModel(),
        //         PersonBookingDto = new PersonBookingDto(personBooking),
        //         SelectedTimes = times.Select(w => new AppointTimeDto(w)).ToList(),
        //         PersonDto = new PersonDto(person)
        //     };
        //
        //     return View(model);
        // }

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
            return await DbContext.AppointTimes
                .Where(w => selection.SelectedTimes.Contains(w.Id))
                .ToListAsync();
        }

        private async Task<List<AppointTimeModel>> GetBookingTimes(Guid bookingId)
        {
            return await DbContext.AppointTimes
                .Where(w => w.PersonBookingId == bookingId)
                .ToListAsync();
        }

        #endregion
    }
}