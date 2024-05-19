using System.Collections.Generic;
using App.cms.Models;

namespace App.Models.Booking
{
    public class RentPlaceModel : Entity<RentPlaceModel>
    {
        public RentPlaceType Type { get; set; }

        public string Name { get; set; }
        
        public List<AppointTimeModel> AppointTimeModels { get; set; }
    }
}