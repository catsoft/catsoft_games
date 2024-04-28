using System.Collections.Generic;
using System.Linq;
using App.ViewModels.Common;

namespace App.ViewModels.Accounting
{
    public class TransactionListViewModel : CommonPageViewModel<TransactionListViewModel>
    {
        public List<TransactionViewModel> Transactions { get; set; }
        
        public AccountingFilterViewModel AccountingFilterViewModel { get; set; }

        public float GetTotalAmount()
        {
            return Transactions.Sum(w => w.TransactionModel.ActualAmount ?? 0.0f);
        }
    }
}