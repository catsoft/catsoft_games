using App.Models.Booking;
using App.ViewModels.Views;

namespace App.ViewModels.Booking
{
    public class PersonDto(PersonModel personModel)
    {
        public PersonModel PersonModel { get; set; } = personModel;

        public static string IsCompanyClassName = "company_data";

        public bool Enabled { get; set; } = true;
        
        public InputViewModel GetPhoneInput() => new("Phone", "Phone", PersonModel.Phone, Enabled);
        public InputViewModel GetEmailInput() => new("Email", "Email", PersonModel.Email, Enabled);
        public InputViewModel GetNifInput() => new("NIF (optional)", "NIF", PersonModel.NIF, Enabled);
        public InputViewModel GetNameInput() => new("Name", "Name", PersonModel.FullName, Enabled);
        public InputViewModel GetCommentInput() => new("Comment (optional)", "Comment", PersonModel.Comment, Enabled);
        public InputViewModel GetCompanyNif() => new("Company NIF", "CompanyNIF", PersonModel.CompanyNIF, Enabled);
        public InputViewModel GetCompanyName() => new("Company Name", "CompanyName", PersonModel.CompanyName, Enabled);
        public InputViewModel GetCompanyAddress() => new("Company Address", "CompanyAddress", PersonModel.CompanyAddress, Enabled);
        public CheckBoxControlViewModel GetIsCompany() => new("Is company", "IsCompany", PersonModel.IsCompany, IsCompanyClassName, Enabled);
    }
}