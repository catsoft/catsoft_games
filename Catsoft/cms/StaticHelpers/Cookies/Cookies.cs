using System;
using System.Collections.Generic;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies.models;
using App.ViewModels.Accounting;
using Microsoft.AspNetCore.Http;

namespace App.cms.StaticHelpers.Cookies
{
    public interface IFilterCookieRepository : ICookieRepository<CmsFilterCookieDto> { }
    
    public interface ILanguageCookieRepository : ICookieRepository<LanguageCookieDto> { }
    
    public interface IBookingSelectionCookieRepository : ICookieRepository<BookingSelectionCookieDto> { }
    
    public interface IPersonDetailsCookieRepository : ICookieRepository<PersonDetailsCookieDto> { }
    
    public interface IAccountingFilterCookieRepository : ICookieRepository<AccountingFilterViewModel> { }
    
    
    public class FilterCookieRepository(IHttpContextAccessor  context) : CookieRepository<CmsFilterCookieDto>(context), IFilterCookieRepository
    {
        public override string Key { get; } = "Filter";
        
        public override CmsFilterCookieDto DefaultValue { get; } = new CmsFilterCookieDto("");
    }
    
    public class LanguageCookieRepository(IHttpContextAccessor  context) : CookieRepository<LanguageCookieDto>(context), ILanguageCookieRepository
    {
        public override string Key { get; } = "Language";
        
        public override LanguageCookieDto DefaultValue { get; } = new(TextLanguage.Portuguese);
    }
    
    public class BookingSelectionCookieRepository(IHttpContextAccessor  context) : CookieRepository<BookingSelectionCookieDto>(context), IBookingSelectionCookieRepository
    {
        public override string Key { get; } = "BookingSelection";
        
        public override BookingSelectionCookieDto DefaultValue { get; } = new(new HashSet<Guid>(), 2);
    }
    
    public class PersonDetailsCookieRepository(IHttpContextAccessor  context) : CookieRepository<PersonDetailsCookieDto>(context), IPersonDetailsCookieRepository
    {
        public override string Key { get; } = "BookingDetails";

        public override PersonDetailsCookieDto DefaultValue { get; } = new();
    }
    
    public class AccountingFilterCookieRepository(IHttpContextAccessor  context) : CookieRepository<AccountingFilterViewModel>(context), IAccountingFilterCookieRepository
    {
        public override string Key { get; } = "AccountingFilter";
        
        public override AccountingFilterViewModel DefaultValue { get; } = new();
    }
}