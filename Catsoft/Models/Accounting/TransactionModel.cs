using App.cms.Controllers.Attributes;
using App.cms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Accounting
{
    [Access]
    public class TransactionModel : Entity<TransactionModel>
    {
        [Show(false, false, false, false)]
        public Guid? AccountFromId { get; set; }

        [Show(false)]
        [ForeignKey("AccountFromId")]
        public AccountModel AccountFromModel { get; set; }

        
        [Show(false, false, false, false)]
        public Guid? AccountToId { get; set; }

        [Show(false)]
        [ForeignKey("AccountToId")]
        public AccountModel AccountToModel { get; set; }



        public decimal? ActualAmount { get; set; }
        public decimal? PlannedAmount { get; set; }

        [Show(false)]
        public string Description { get; set; }
        [Show(false)]
        public string Note { get; set; }

        public DateTime Date { get; set; }

        public TransactionCategory Category { get; set; }

        public bool IsPaid { get; set; }

        public bool ForRecell { get; set; }


        [Show(false)]
        public decimal? TemplateAmount { get; set; }

        [Show(false)]
        public bool IsTemplate { get; set; }

        [Show(false, false, false, false)]
        public Guid? TemplateTransactionId { get; set; }

        [Show(false)]
        [ForeignKey("TemplateTransactionId")]
        public TransactionModel TemplateTransaction { get; set; }


        [Show(false, false, false, false)]
        public List<TransactionModel> ActualTransactions { get; set; }


        [Show(false)]
        public decimal? TypeAmount { get; set; }
        [Show(false)]
        public decimal? TypeQuantity { get; set; }


        [Show(false)]
        public bool IsRecurring { get; set; }

        [Show(false)]
        public RecurringFrequency RecurringFrequency { get; set; } = RecurringFrequency.Month;

        [Show(false)]
        public DateTime? RecurringStart { get; set; }

        [Show(false)]
        public DateTime? RecurringEnd { get; set; }



        [Show(false)]
        public string BillLink { get; set; }


        [Show(false, false, false, false)]
        public Guid? BillFileId { get; set; }

        [Show(false, false)]
        [Required]
        public FileModel BillFile { get; set; }


        //public List<string> Items { get; set; }
    }


    public enum CalculateType
    {
        Amount,
        Quantity,
        Monthly
    }

    public enum RecurringFrequency
    {
        Day,
        Week,
        Month,
        Year,
    }

    public enum TransactionCategory
    {
        Tax,
        Payroll,
        PayrolVacation,
        Payroll13th,
        PayrollBonus,
        Fees,
        Subscription,
        Insurance,
        Rent,
        Utilities,
        Supplies,
        Equipment,
        Software,
        Legal,
        Accounting,
        Marketing,
        Travel,
        Meals,
        Entertainment,
        Office,
        Internet,
    }
}