using System.Collections.Generic;
using App.ViewModels.Common;

namespace App.ViewModels.Accounting
{
    public class TransactionListViewModel : CommonPageViewModel<TransactionListViewModel>
    {
        public List<TransactionViewModel> Transactions { get; set; }
        
        public AccountingFilterViewModel AccountingFilterViewModel { get; set; }
    }
}