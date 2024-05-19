using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Models.Booking;

namespace App.cms.ObjectInterceptors
{
    public class AppointRuleInterceptors(CatsoftContext catsoftContext) : IObjectInterceptor<AppointRuleModel>
    {
        public async void Intercept(AppointRuleModel obj)
        {
            await CleanNotBooked();

            var rules = catsoftContext.AppointRules.OrderBy(w => w.Position).ToList();

            foreach (var rule in rules)
            {
                if (rule.AppointRuleType == AppointRuleType.Create)
                {
                    await DoCreating(rule);
                }
                else if (rule.AppointRuleType == AppointRuleType.Block)
                {
                    await DoBlocking(rule);
                }

                if (rule.AppointRuleType == AppointRuleType.UpdatePrice)
                {
                    await DoPriceUpdate(rule);
                }
            }
        }

        private async Task DoCreating(AppointRuleModel rule)
        {
            var places = catsoftContext.RentPlaces.ToList();
            var date = rule.DateStart;
            var dateOfWeeks = Options.Options.BookingDateOfWeeks;

            while (date <= rule.DateEnd)
            {
                if (!dateOfWeeks.Contains(date.DayOfWeek)) continue;

                var time = rule.TimeStart;

                while (time <= rule.TimeEnd)
                {
                    var endTime = time.Add(Options.Options.BookingTimeRange);
                    var times = catsoftContext.AppointTimes.Where(w => w.Date == date && w.TimeStart == time).ToList();

                    foreach (var place in places)
                    {
                        if (times.Any(w => w.RentPlaceModelId == place.Id)) continue;
                        
                        var appointTime = new AppointTimeModel
                        {
                            Date = date,
                            TimeStart = time,
                            TimeEnd = endTime,
                            RentPlaceModelId = place.Id,
                            Price = rule.Price,
                            Booked = false,
                            Paid = false
                        };
                        catsoftContext.Add(appointTime);
                    }

                    time = endTime;
                }

                date = date.AddDays(1);
            }

            await catsoftContext.SaveChangesAsync();
        }

        private async Task DoBlocking(AppointRuleModel rule)
        {
            var times = GetByRule(rule);
            times.ForEach(w => w.Blocked = true);
            catsoftContext.UpdateRange(times);
            await catsoftContext.SaveChangesAsync();
        }

        private async Task DoPriceUpdate(AppointRuleModel rule)
        {
            var times = GetByRule(rule);
            times.ForEach(w => w.Price = rule.Price);
            catsoftContext.UpdateRange(times);
            await catsoftContext.SaveChangesAsync();
        }

        private List<AppointTimeModel> GetByRule(AppointRuleModel rule)
        {
            return catsoftContext.AppointTimes.Where(w => w.Date >= rule.DateStart && w.Date <= rule.DateEnd
            && w.TimeStart >= rule.TimeStart && w.TimeEnd <= rule.TimeEnd).ToList();
        }

        private async Task CleanNotBooked()
        {
            var items = catsoftContext.AppointTimes.Where(w => !w.Booked && !w.Paid).ToList();

            catsoftContext.RemoveRange(items);
            await catsoftContext.SaveChangesAsync();
        }
    }
}