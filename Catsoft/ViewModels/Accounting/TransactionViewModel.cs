﻿using App.Models.Accounting;
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
            return TransactionModel.Date.ToString("dd MMM yyyy");
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
            return TransactionModel.ActualAmount.ToString();
        }

        public string GetPlannedAmount()
        {
            return TransactionModel.PlannedAmount.ToString();
        }

        public bool IsPaid()
        {
            return TransactionModel.IsPaid;
        }
        
        public string GetBillLink()
        {
            var bill = TransactionModel.BillLink;
            if (bill.IsNullOrEmpty())
            {
                bill = "file/"+ TransactionModel.BillFile?.Path;
            }
            return bill;
        }
    }
}