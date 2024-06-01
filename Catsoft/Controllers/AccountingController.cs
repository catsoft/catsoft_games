using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.cms.FilesHandlers;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
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
        private readonly IZipHandler _zipHandler;

        public AccountingController(CatsoftContext dbContext, IZipHandler zipHandler)
        {
            _zipHandler = zipHandler;
            base.DbContext = dbContext;
        }

        public async Task<IActionResult> TransactionList()
        {
            var transaction = await GetTransactionByFilter();
            var filter = GetFilter();

            var home = new TransactionListViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Accounting),
                FooterViewModel = await GetFooterViewModel(),
                Transactions = transaction,
                AccountingFilterViewModel = filter
            };

            return View(home);
        }

        private IQueryable<TransactionModel> GetTransactions()
        {
            return DbContext.TransactionModels
                .Where(w => w.IsDeleted == false)
                .Include(w => w.BillImageModel)
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .Include(w => w.BillFile)
                .OrderBy(w => w.Date);   
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
        
        public async Task<IActionResult> TransactionDetails(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = DbContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .Include(w => w.BillFile)
                .FirstOrDefault(w => w.Id == id);
            
            var home = new TransactionViewModel()
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Accounting),
                FooterViewModel = await GetFooterViewModel(),
                TransactionModel = transaction,
            };

            return View(home);
        }
        
        [HttpPost]
        public IActionResult TransactionPay(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = DbContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .FirstOrDefault(w => w.Id == id);

            if (transaction != null) 
            {
                transaction.IsPaid = true;
                DbContext.Update(transaction);
                DbContext.SaveChanges();
            }
            return RedirectToAction("TransactionList");
        }

                
        [HttpPost]
        public IActionResult TransactionDelete(string transactionUuid)
        {
            var id = Guid.Parse(transactionUuid);
            var transaction = DbContext.TransactionModels
                .Include(w => w.AccountFromModel)
                .Include(w => w.AccountToModel)
                .Include(w => w.TemplateTransaction)
                .FirstOrDefault(w => w.Id == id);

            if (transaction != null) 
            {
                transaction.IsDeleted = true;
                DbContext.Update(transaction);
                DbContext.SaveChanges();
            }
            return RedirectToAction("TransactionList");
        }
        
        public IActionResult TransactionEditCreate(string transactionUuid)
        {
            return RedirectToAction("Edit", "HomeCms", routeValues: new
            {
                type = typeof(TransactionModel).FullName,
                id = transactionUuid
            } );
            
            // TransactionModel transactionModel;
            // if (transactionUuid.IsNullOrEmpty())
            // {
            //     transactionModel = new TransactionModel();
            // }
            // else
            // {
            //     var id = Guid.Parse(transactionUuid);
            //     transactionModel = CatsoftContext.TransactionModels
            //         .Include(w => w.AccountFromModel)
            //         .Include(w => w.AccountToModel)
            //         .Include(w => w.TemplateTransaction)
            //         .FirstOrDefault(w => w.Id == id);
            // }
            //
            // var home = new TransactionViewModel()
            // {
            //     HeaderViewModel = GetHeaderViewModel(),
            //     FooterViewModel = GetFooterViewModel(),
            //     TransactionModel = transactionModel,
            // };
            //
            // return View(home);
        }

        [HttpPost]
        public IActionResult TransactionEditCreate(TransactionModel transactionModel)
        {
            DbContext.Update(transactionModel);
            DbContext.SaveChanges();

            return RedirectToAction("TransactionList");
        }

        public async Task<IActionResult> TransactionGetAllBills()
        {
            var transactions = await GetTransactionByFilter();
            
            var files = transactions.SelectMany(w => w.GetBillLinks()).ToList();
            var zipFile = _zipHandler.GenerateZip(files);

            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var fileName = "bills_"+ date + ".zip";
            
            return File(System.IO.File.ReadAllBytes(zipFile), "application/zip", fileName);
        }


        [HttpGet]
        public IActionResult CreateTemplate()
        {
            return RedirectToAction("Create", "HomeCms", routeValues: new { type = typeof(TransactionModel).FullName} );
        }
        
        [HttpGet]
        public IActionResult CreateTransaction()
        {
            return RedirectToAction("Create", "HomeCms", routeValues: new { type = typeof(TransactionModel).FullName} );
        }

        
        [HttpPost]
        public IActionResult CreateTemplate(TransactionModel transactionModel)
        {
            DbContext.Add(transactionModel);
            DbContext.SaveChanges();
            return RedirectToAction("TransactionList");
        }
        

        private async Task<List<TransactionViewModel>> GetTransactionByFilter()
        {
            var filter = GetFilter();
            var transactionQuery = GetTransactions();

            return await FilterTransactions(transactionQuery, filter)
                .Select(w => new TransactionViewModel
                {
                    TransactionModel = w,
                    AccountFromViewModel = new AccountViewModel(w.AccountFromModel),
                    AccountToViewModel = new AccountViewModel(w.AccountToModel)
                })
                .ToListAsync();   
        }

        private AccountingFilterViewModel GetFilter()
        {
            var filter = CookieHelper.GetValue<AccountingFilterViewModel>(HttpContext, "AccountingFilter");
            
            if (filter == null)
            {
                filter = new AccountingFilterViewModel();
            }
            filter.AccountingPairs = GetAccountSelector();
            filter.TemplatesPairs = GetTemplatesSelector();
            return filter;
        }
        
        private List<KeyValueViewModel> GetAccountSelector() => DbContext.AccountModels
                .Select(w => new KeyValueViewModel(w.Name, w.Id.ToString()))
                .ToList();

        private List<KeyValueViewModel> GetTemplatesSelector() => DbContext.TransactionModels
            .Where(w => w.IsTemplate && w.IsRecurring)
            .Include(w => w.AccountFromModel)
            .Include(w => w.AccountToModel)
            .ToList()
            .Select(w => new KeyValueViewModel(w.Title, w.Id.ToString()))
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

            if (filter.Template != null)
            {
                var templateId = Guid.Parse(filter.Template);
                transactions = transactions.Where(w => w.TemplateTransactionId == templateId || w.Id == templateId);
            }
            
            if (filter.DateFrom != null)
            {
                transactions = transactions.Where(w => w.Date >= filter.DateFrom);
            }
            
            if (filter.DateTo != null)
            {
                transactions = transactions.Where(w => w.Date <= filter.DateTo);
            }
            
            return transactions;
        }
    }
}