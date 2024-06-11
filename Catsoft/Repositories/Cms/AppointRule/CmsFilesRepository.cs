using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Options;
using App.cms.Repositories;
using App.Models;
using App.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Cms.AppointRule
{
    public class AppointRuleRepository(CatsoftContext catsoftContext)
        : CmsBaseRepository<AppointRuleModel, CatsoftContext>(catsoftContext), IAppointRuleRepository
    {
        private readonly CatsoftContext _catsoftContext = catsoftContext;

        public async Task<double> PriceForTheDate(DateOnly dateOnly)
        {
            var rules = await _catsoftContext.AppointRules.Where(w => w.DateStart <= dateOnly && w.DateEnd >= dateOnly)
                .OrderBy(w => w.Position)
                .ToListAsync();

            var rule = rules.LastOrDefault(w => w.AppointRuleType is AppointRuleType.Create or AppointRuleType.UpdatePrice);

            if (rule == null)
            {
                return Options.Booking.DefaultPrice;
            }

            return (double)rule.Price;
        }
    }
}