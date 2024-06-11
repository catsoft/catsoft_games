using System;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.Repositories;
using App.Models.Booking;

namespace App.Repositories.Cms.AppointRule
{
    public interface IAppointRuleRepository : ICmsBaseRepository<AppointRuleModel>
    {
        public Task<double> PriceForTheDate(DateOnly dateOnly);
    }
}