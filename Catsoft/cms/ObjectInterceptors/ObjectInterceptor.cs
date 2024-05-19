using System;
using System.Collections.Generic;
using App.cms.Models;
using App.cms.Repositories.File;
using App.Models;
using App.Models.Accounting;
using App.Models.Booking;
using Microsoft.AspNetCore.Hosting;

namespace App.cms.ObjectInterceptors
{
    public class ObjectInterceptor(
        IObjectInterceptor<TransactionModel> transactionInterceptor,
        IObjectInterceptor<AppointRuleModel> appointRuleInterceptor,
        IWebHostEnvironment webHostEnvironment,
        ICmsFilesRepository cmsFilesRepository,
        CatsoftContext catsoftContext) : IObjectInterceptor
    {
        public void Intercept(object obj)
        {
            if (obj is TransactionModel)
            {
                transactionInterceptor.Intercept(obj as TransactionModel);
            }

            if (obj is AppointRuleModel)
            {
                appointRuleInterceptor.Intercept(obj as AppointRuleModel);
            }
        }
    }
}