using System;
using System.Threading.Tasks;
using App.cms.Repositories;
using App.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Cms.AppointRule
{
    public class AppointRuleRepository<TContext>
        (TContext catsoftContext) : CmsBaseRepository<AppointRuleModel, TContext>(catsoftContext), IAppointRuleRepository
        where TContext : DbContext
    {
        public async Task<double> PriceForTheDate(DateOnly dateOnly)
        {
            return 0.0;
        }
    }
}