using System;
using System.Collections.Generic;
using System.Linq;
using App.cms.StaticHelpers;
using App.Models;
using App.Models.Accounting;
using App.ViewModels.Accounting;
using App.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;

namespace App.Controllers
{
    public class AccountingController : CommonController
    {
        public AccountingController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult TransactionList()
        {
            var filter = CookieHelper.GetValue<AccountingFilterViewModel>(HttpContext, "AccountingFilter");
            
            if (filter == null)
            {
                filter = new AccountingFilterViewModel();
            }
            filter.AccountingPairs = GetAccountSelector();

            var transactionQuery = GetTransactions();

            var transaction = FilterTransactions(transactionQuery, filter)
                .Select(w => new TransactionViewModel
                {
                    TransactionModel = w,
                    AccountFromViewModel = new AccountViewModel(w.AccountFromModel),
                    AccountToViewModel = new AccountViewModel(w.AccountToModel)
                })
                .ToList();

            transaction = LoadImages(transaction.ToList());
            
            var home = new TransactionListViewModel
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Transactions = transaction,
                AccountingFilterViewModel = filter
            };

            return View(home);
        }

        private IQueryable<TransactionModel> GetTransactions()
        {
            return CatsoftContext.TransactionModels
                .Where(w => w.IsDeleted == false)
                .Include(w => w.BillImageModel)
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .Include(w => w.BillFile);   
        }
        
        private List<TransactionViewModel> LoadImages(List<TransactionViewModel> transactions)
        {
            transactions.ForEach(w =>
                w.TransactionModel.BillImageModel = CatsoftContext.Images.FirstOrDefault(c => c.Id == w.TransactionModel.BillImageModelId));
            return transactions;
        }
        
        [HttpPost]
        public IActionResult SaveFilter(AccountingFilterViewModel filterViewModel)
        {
            CookieHelper.SaveValue(HttpContext, "AccountingFilter", filterViewModel);
            return RedirectToAction("TransactionList");
        }

        [HttpPost]
        public IActionResult CleanFilter()
        {
            CookieHelper.SaveValue(HttpContext, "AccountingFilter", new AccountingFilterViewModel());
            return RedirectToAction("TransactionList");
        }
        
        public IActionResult TransactionDetails(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = CatsoftContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .Include(w => w.BillFile)
                .FirstOrDefault(w => w.Id == id);
            
            var home = new TransactionViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                TransactionModel = transaction,
            };

            return View(home);
        }
        
        [HttpPost]
        public IActionResult TransactionPay(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = CatsoftContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .FirstOrDefault(w => w.Id == id);

            if (transaction != null) 
            {
                transaction.IsPaid = true;
                CatsoftContext.Update(transaction);
                CatsoftContext.SaveChanges();
            }
            return RedirectToAction("TransactionList");
        }

                
        [HttpPost]
        public IActionResult TransactionDelete(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = CatsoftContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .FirstOrDefault(w => w.Id == id);

            if (transaction != null) 
            {
                transaction.IsDeleted = true;
                CatsoftContext.Update(transaction);
                CatsoftContext.SaveChanges();
            }
            return RedirectToAction("TransactionList");
        }
        
        public IActionResult TransactionEditCreate(string transactionUuid)
        {
            TransactionModel transactionModel;
            if (transactionUuid.IsNullOrEmpty())
            {
                transactionModel = new TransactionModel();
            }
            else
            {
                var id = Guid.Parse(transactionUuid);
                transactionModel = CatsoftContext.TransactionModels
                    .Include(w => w.AccountFromModel)
                    .Include(w => w.AccountToModel)
                    .Include(w => w.TemplateTransaction)
                    .FirstOrDefault(w => w.Id == id);
            }
            
            var home = new TransactionViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                TransactionModel = transactionModel,
            };

            return View(home);
        }

        [HttpPost]
        public IActionResult TransactionEditCreate(TransactionModel transactionModel)
        {
            CatsoftContext.Update(transactionModel);
            CatsoftContext.SaveChanges();

            return RedirectToAction("TransactionList");
        }
        
        private List<KeyValueViewModel> GetAccountSelector() => CatsoftContext.AccountModels
                .Select(w => new KeyValueViewModel(w.Name, w.Id.ToString()))
                .ToList();

        private IQueryable<TransactionModel> FilterTransactions(IQueryable<TransactionModel> transactions,
            AccountingFilterViewModel filter)
        {
            if (filter.HaveBill)
            {
                transactions = transactions.Where(w => w.BillLink != null || w.BillFileId != null);
            }

            if (filter.NoBill)
            {
                transactions = transactions.Where(w => w.BillLink == null && w.BillFileId == null);
            }

            if (filter.Category != null)
            {
                try
                {
                    var category = Enum.Parse<TransactionCategory>(filter.Category);
                    transactions = transactions.Where(w => w.Category == category);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (filter.Paid)
            {
                transactions = transactions.Where(w => w.IsPaid);
            }

            if (filter.NotPaid)
            {
                transactions = transactions.Where(w => w.IsPaid == false);
            }

            if (filter.AccountFrom != null)
            {
                var accountGuid = Guid.Parse(filter.AccountFrom);
                transactions = transactions.Where(w => w.AccountFromModelId == accountGuid);
            }

            if (filter.AccountTo != null)
            {
                var accountGuid = Guid.Parse(filter.AccountTo);
                transactions = transactions.Where(w => w.AccountToModelId == accountGuid);
            }

            if (filter.DateTimeFrom != null)
            {
                transactions = transactions.Where(w => w.Date >= filter.DateTimeFrom);
            }
            
            if (filter.DateTimeTo != null)
            {
                transactions = transactions.Where(w => w.Date <= filter.DateTimeTo);
            }
            
            return transactions;
        }
    }
}