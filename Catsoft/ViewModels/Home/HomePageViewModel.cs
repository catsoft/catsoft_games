using App.Models.Pages;
using App.ViewModels.About;
using App.ViewModels.Common;
using App.ViewModels.Contacts;
using App.ViewModels.Projects;
using App.ViewModels.Services;

namespace App.ViewModels.Home
{
    public class HomePageViewModel : CommonPageViewModel<MainPageModel>
    {
        public ContactsPageViewModel ContactsPageViewModel { get; set; }

        public AboutPageViewModel AboutPageViewModel { get; set; }

        public ServicesPageViewModel ServicesPageViewModel { get; set; }

        public ProjectsPageViewModel ProjectsPageViewModel { get; set; }
    }
}
