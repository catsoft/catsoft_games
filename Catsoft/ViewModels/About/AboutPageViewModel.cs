using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.About
{
    public class AboutPageViewModel : PartialPageViewModel<AboutPageModel>
    {
        public AboutPageViewModel()
        {
            
        }

        public AboutPageViewModel(AboutPageModel aboutPageModel) : base(aboutPageModel)
        {
            
        }
    }
}
