using System;
using System.Collections.Generic;
using System.Linq;
using App.cms.Repositories.File;
using App.Models;
using App.Models.Accounting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace App.cms.ObjectInterceptors
{
    public class ObjectInterceptor(IWebHostEnvironment webHostEnvironment, ICmsFilesRepository cmsFilesRepository, CatsoftContext catsoftContext) : IObjectInterceptor
    {
        public void Intercept(object obj)
        {
            if (obj.GetType() == typeof(TransactionModel))
            {
                DoTransactionInterception(obj as TransactionModel);
            }
        }

        private void DoTransactionInterception(TransactionModel transactionModel)
        {
            // Я хочу создать темплейты транзакции если это темплейт и рекурентный платеж
            // либо обновить если они уже есть, обновить в целом все поля
            if (transactionModel.IsTemplate && transactionModel.IsRecurring)
            {
                // сначала я хочу стереть все связанные транзакции которые теплейты
                // и потом создать новые на остаток
                // для себя сделаю чтобы рекурентные транзакции не удалялись и не редактировались совсем
                var oldTransactions = catsoftContext.TransactionModels.Where(w=> w.TemplateTransactionId == transactionModel.Id).ToList();
                catsoftContext.RemoveRange(oldTransactions);
                catsoftContext.SaveChanges();

                if (!oldTransactions.IsNullOrEmpty())
                {
                    transactionModel.RecurringStart = oldTransactions.Max(m => m.Date);
                }
                
                // теперь создаю новые транзакции
                var newTransactions = GetRecurrentTransactions(transactionModel);
                catsoftContext.AddRange(newTransactions);
                catsoftContext.SaveChanges();
            }
        }

        private List<TransactionModel> GetRecurrentTransactions(TransactionModel transactionModel)
        {
            var result = new List<TransactionModel>();

            var startDate = transactionModel.RecurringStart ?? DateOnly.FromDateTime(DateTime.Now);
            var endDate = transactionModel.RecurringEnd ?? DateOnly.FromDateTime(DateTime.Now);
            while (startDate <= endDate)
            {
                var copy = GetTemplateCopy(transactionModel);
                copy.Date = startDate;
                result.Add(copy);
                switch (transactionModel.RecurringFrequency)
                {
                    case RecurringFrequency.Day:
                        startDate = startDate.AddDays(1);
                        break;
                    case RecurringFrequency.Week:
                        startDate = startDate.AddDays(7);
                        break;
                    case RecurringFrequency.Month:
                        startDate = startDate.AddMonths(1);
                        break;
                    case RecurringFrequency.Year:
                        startDate = startDate.AddYears(1);
                        break;
                }
            }

            return result;
        }

        private TransactionModel GetTemplateCopy(TransactionModel transactionModel)
        {
            return new TransactionModel()
            {
                IsTemplate = true,
                IsRecurring = false,
                AccountFromModelId = transactionModel.AccountFromModelId,
                Description = transactionModel.Description,
                Note = transactionModel.Note,
                AccountToModelId = transactionModel.AccountToModelId,
                ActualAmount = transactionModel.TemplateAmount,
                PlannedAmount = transactionModel.TemplateAmount,
                Date = transactionModel.Date,
                Category = transactionModel.Category,
                IsPaid = false,
                ForResell = transactionModel.ForResell,
                TemplateTransactionId = transactionModel.Id,
                TemplateAmount = transactionModel.TemplateAmount,
            };
        }
    }
}