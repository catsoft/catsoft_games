using App.ViewModels.Common;

namespace App.ViewModels.Services
{
    public class AllServicesPageViewModel : CommonPageViewModel
    {
        public AllServicesPageViewModel()
        {

        }

        public AllServicesPageViewModel(HeaderViewModel headerViewModel, FooterViewModel footerViewModel) : base(headerViewModel, footerViewModel)
        {
        }
    }
}