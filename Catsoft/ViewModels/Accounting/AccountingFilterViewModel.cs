using System;
using System.Collections.Generic;
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

        public DateTime? DateTimeFrom { get; set; }
        
        public DateTime? DateTimeTo { get; set; }

        
        public List<KeyValueViewModel> AccountingPairs { get; set; }
    }
}