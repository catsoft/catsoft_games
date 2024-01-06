using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Services
{
    public class ServicesPageViewModel : PartialPageViewModel<ServicesPageModel>
    {
        public ServicesPageViewModel()
        {
            
        }

        public ServicesPageViewModel(ServicesPageModel servicesPageModel) : base(servicesPageModel)
        {
            
        }
        
        public List<ServiceModel> ServiceModels { get; set; }
    }
}
