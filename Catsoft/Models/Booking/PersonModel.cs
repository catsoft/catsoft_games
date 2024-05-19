using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class PersonModel : Entity<PersonModel>
    {
        [DataType(DataType.PhoneNumber)] public string Phone { get; set; }

        [DataType(DataType.EmailAddress)] public string Email { get; set; }

        public string FullName { get; set; }

        public string Comment { get; set; }

        public string NIF { get; set; }

        public string CompanyName { get; set; }
        
        [Show(false, false)]
        public List<PersonBookingModel> PersonBookingModels { get; set; }
    }
}