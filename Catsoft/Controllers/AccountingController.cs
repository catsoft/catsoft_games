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

            
            var transactionQuery = CatsoftContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .Include(w => w.BillFile);


            var transaction = FilterTransactions(transactionQuery, filter)
                .Select(w => new TransactionViewModel
                {
                    TransactionModel = w,
                    AccountFromViewModel = new AccountViewModel(w.AccountFromModel),
                    AccountToViewModel = new AccountViewModel(w.AccountToModel)
                })
                .ToList();
            
            var home = new TransactionListViewModel
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Transactions = transaction,
                AccountingFilterViewModel = filter
            };

            return View(home);
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

        public IActionResult TransactionEditCreate(string transactionUuid)
        {
            Guid? id = transactionUuid != null ? Guid.Parse(transactionUuid) : null;
            var transaction = CatsoftContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
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
        public IActionResult TransactionEditCreate(TransactionModel transactionModel)
        {
            CatsoftContext.Update(transactionModel);
            CatsoftContext.SaveChanges();

            return RedirectToAction("TransactionList");
        }
        
        private List<KeyValueViewModel> GetAccountSelector() => CatsoftContext.AccountModels
                .Select(w => new KeyValueViewModel(w.Id.ToString(), w.Name))
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
                transactions = transactions.Where(w => w.AccountFromId == accountGuid);
            }

            if (filter.AccountTo != null)
            {
                var accountGuid = Guid.Parse(filter.AccountTo);
                transactions = transactions.Where(w => w.AccountToId == accountGuid);
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