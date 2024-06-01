using App.Models.Booking;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class PersonDetailsCookieDto(PersonModel personModel)
    {
        public PersonModel PersonModel { get; set; } = personModel;
    }
}