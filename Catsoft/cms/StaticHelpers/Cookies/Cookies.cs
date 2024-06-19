using System;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies.models;
using App.Models.Booking;
using App.ViewModels.Accounting;
using Microsoft.AspNetCore.Http;

namespace App.cms.StaticHelpers.Cookies
{
    public interface IFilterCookieRepository : ICookieRepository<CmsFilterCookieDto>
    {
    }

    public interface ILanguageCookieRepository : ICookieRepository<LanguageCookieDto>
    {
    }

    public interface IBookingSelectionCookieRepository : ICookieRepository<BookingSelectionCookieDto>
    {
        public Task<PersonBookingModel> GetWithUpdate(Func<Guid?, Task<PersonBookingModel>> getBooking);

        public Task<PersonModel> GetWithUpdate(Func<Guid?, Task<PersonModel>> getModel);
    }

    public interface IBookingHistoryCookieRepository : ICookieRepository<BookingHistoryCookieDto>
    {
    }

    public interface IAccountingFilterCookieRepository : ICookieRepository<AccountingFilterViewModel>
    {
    }

    public interface ICmsTextResourcesCookieRepository : ICookieRepository<CmsTextResourceCookieDto>
    {
    }

    public interface ILocalOptionsCookieRepository : ICookieRepository<LocalOptionsCookieDto>
    {
        public bool BookingEnabled();

        public bool GameSelectionEnabled();
    }


    public class FilterCookieRepository(IHttpContextAccessor context) : CookieRepository<CmsFilterCookieDto>(context), IFilterCookieRepository
    {
        public override CmsFilterCookieDto DefaultValue { get; } = new("");
        public override string Key { get; } = "Filter";
    }

    public class LanguageCookieRepository(IHttpContextAccessor context) : CookieRepository<LanguageCookieDto>(context), ILanguageCookieRepository
    {
        public override LanguageCookieDto DefaultValue { get; } = new(TextLanguage.Portuguese);
        public override string Key { get; } = "Language";
    }

    public class BookingSelectionCookieRepository(IHttpContextAccessor context)
        : CookieRepository<BookingSelectionCookieDto>(context), IBookingSelectionCookieRepository
    {
        public override BookingSelectionCookieDto DefaultValue { get; } = new();
        public override string Key { get; } = "BookingSelection";

        public async Task<PersonBookingModel> GetWithUpdate(Func<Guid?, Task<PersonBookingModel>> getBooking)
        {
            var value = GetValue();
            var booking = await getBooking(value.GetBookingGuidOrDefault());
            value.BookingId = booking.Id.ToString();
            SaveValue(value);
            return booking;
        }
        
        public async Task<PersonModel> GetWithUpdate(Func<Guid?, Task<PersonModel>> getModel)
        {
            var value = GetValue();
            var model = await getModel(value.GetPersonGuidOrDefault());
            value.PersonId = model.Id.ToString();
            SaveValue(value);
            return model;
        }
    }

    public class BookingHistoryCookieRepository(IHttpContextAccessor context)
        : CookieRepository<BookingHistoryCookieDto>(context), IBookingHistoryCookieRepository
    {
        public override BookingHistoryCookieDto DefaultValue { get; } = new();
        public override string Key { get; } = "BookingHistory";
    }

    public class AccountingFilterCookieRepository(IHttpContextAccessor context)
        : CookieRepository<AccountingFilterViewModel>(context), IAccountingFilterCookieRepository
    {
        public override AccountingFilterViewModel DefaultValue { get; } = new();
        public override string Key { get; } = "AccountingFilter";
    }

    public class CmsTextResourcesCookieRepository(IHttpContextAccessor context)
        : CookieRepository<CmsTextResourceCookieDto>(context), ICmsTextResourcesCookieRepository
    {
        public override CmsTextResourceCookieDto DefaultValue { get; } = new(false);
        public override string Key { get; } = "CmsTextResources";
    }

    public class LocalOptionsCookieRepository(IHttpContextAccessor context)
        : CookieRepository<LocalOptionsCookieDto>(context), ILocalOptionsCookieRepository
    {
        public override LocalOptionsCookieDto DefaultValue { get; } = new();
        public override string Key { get; } = "LocalOptions";

        public bool GameSelectionEnabled() { return GetValue().ToggleFeatures.Contains(Options.Options.Features.GameSelection); }

        public bool BookingEnabled() { return true; }
    }
}