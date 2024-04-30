using System.Collections.Generic;
using System.Reflection.Emit;
using App.Models.Accounting;
using App.Utils;
using App.ViewModels.Common;
using Microsoft.IdentityModel.Tokens;

namespace App.ViewModels.Accounting
{
    public class TransactionViewModel: CommonPageViewModel<TransactionListViewModel>
    {
        public TransactionModel TransactionModel { get; set; }

        public AccountViewModel AccountFromViewModel { get; set; }

        public AccountViewModel AccountToViewModel { get; set; }

        public string GetDate()
        {
            return TransactionModel.Date.ToString("dd.MM.yyyy");
        }

        public string AccountFromName()
        {
            return AccountFromViewModel?.AccountModel?.Name;
        }

        public string AccountToName()
        {
            return AccountToViewModel?.AccountModel?.Name;
        }

        public string GetCategoryName()
        {
            return TransactionModel.Category.ToString();
        }

        public string GetAmount()
        {
            var amount = TransactionModel.IsTemplate ? TransactionModel.TemplateAmount : TransactionModel.ActualAmount;
            return amount.ToString();
        }

        public string GetPlannedAmount()
        {
            return TransactionModel.PlannedAmount.ToString();
        }

        public bool IsPaid()
        {
            return TransactionModel.IsPaid;
        }
        
        public List<string> GetBillLinks()
        {
            var result = new List<string>();
            
            result.AddIfNotEmpty(TransactionModel.BillImageModel?.OriginalUrl);
            result.AddIfNotEmpty(TransactionModel.BillFile?.Path);
            result.AddIfNotEmpty(TransactionModel.BillLink);

            return result;
        }

        public bool HaveBill()
        {
            return !GetBillLinks().IsNullOrEmpty();
        }
    }
}