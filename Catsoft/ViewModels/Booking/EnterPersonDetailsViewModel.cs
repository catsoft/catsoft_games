using System;

namespace App.ViewModels.Booking
{
    public class EnterPersonDetailsViewModel
    {
        public Guid Id { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }
        public string NIF { get; set; }

        public string FullName { get; set; }
        
        public string Comment { get; set; }
        
        public string IsCompany { get; set; }
        
        public string CompanyNIF { get; set; }

        public string CompanyName { get; set; }
        
        public string CompanyAddress { get; set; }
    }
}