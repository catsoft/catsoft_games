using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class RentPlaceModel : Entity<RentPlaceModel>
    {
        public RentPlaceType RentPlaceType { get; set; }

        public string Name { get; set; }
        
        [Show(false, false, false, false)]
        public List<AppointTimeModel> AppointTimeModels { get; set; }
    }
}