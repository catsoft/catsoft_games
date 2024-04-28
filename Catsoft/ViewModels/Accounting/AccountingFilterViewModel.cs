using System;
using System.Collections.Generic;
using App.Models.Accounting;
using App.ViewModels.Views;

namespace App.ViewModels.Accounting
{
    public class AccountingFilterViewModel
    {
        public bool Paid { get; set; }
        
        public bool NotPaid { get; set; }
        
        public string AccountFrom { get; set; }
        
        public string AccountTo { get; set; }
        
        public bool HaveBill { get; set; }
        
        public bool NoBill { get; set; }
        
        public string Category { get; set; }

        public DateOnly? DateFrom { get; set; }
        
        public DateOnly? DateTo { get; set; }
        
        public string Template { get; set; }
        

        public List<KeyValueViewModel> TemplatesPairs { get; set; }

        public List<KeyValueViewModel> AccountingPairs { get; set; }
    }
}