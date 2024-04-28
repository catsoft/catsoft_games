﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Accounting
{
    [Access]
    public class TransactionModel : Entity<TransactionModel>
    {
        public override string Title => AccountFromModel?.Title + " -> " + AccountToModel?.Title + " " + ActualAmount;


        [Show(false, false, false, false)] public Guid? AccountFromModelId { get; set; }
        [Show(false)]
        public AccountModel AccountFromModel { get; set; }

        
        [Show(false, false, false, false)] 
        public Guid? AccountToModelId { get; set; }

        [Show(false)]
        public AccountModel AccountToModel { get; set; }
        
        public float? ActualAmount { get; set; }
        
        [Show(showInCreate: false)] 
        public float? PlannedAmount { get; set; }

        [Show(false)] public string Description { get; set; }

        [Show(false)] public string Note { get; set; }

        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public TransactionCategory Category { get; set; }

        public bool IsPaid { get; set; }

        public bool ForResell { get; set; }


        [Show(false)] public float? TemplateAmount { get; set; }

        // Типо шаблонная транзакция
        [Show(false)] public bool IsTemplate { get; set; }

        [Show(false, false, false, false)] public Guid? TemplateTransactionId { get; set; }

        [Show(false)]
        [ForeignKey("TemplateTransactionId")]
        public TransactionModel TemplateTransaction { get; set; }


        [Show(false, false, false, false)] public List<TransactionModel> ActualTransactions { get; set; }


        [Show(false)] public bool IsRecurring { get; set; }

        [Show(false)] public RecurringFrequency RecurringFrequency { get; set; } = RecurringFrequency.Month;

        [Show(false)] public DateOnly? RecurringStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Show(false)] public DateOnly? RecurringEnd { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(5));


        [Show(false)]
        [DataType(DataType.Url)]
        public string BillLink { get; set; }


        [Show(false, false, false, false)] public Guid? BillFileId { get; set; }

        [Show(false, false)]
        [ForeignKey("BillFileId")]
        public FileModel BillFile { get; set; }
        
        
        
        [Show(false, false, false, false)] public Guid? BillImageModelId { get; set; }

        [ForeignKey("BillImageModelId")]
        public ImageModel BillImageModel { get; set; }


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
        Year
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
        Internet
    }
}