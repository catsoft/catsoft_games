using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class PersonDto(PersonModel personModel)
    {
        public PersonModel PersonModel { get; set; } = personModel;

        public string GetContact() => PersonModel.Phone ?? PersonModel.Email;
    }
}