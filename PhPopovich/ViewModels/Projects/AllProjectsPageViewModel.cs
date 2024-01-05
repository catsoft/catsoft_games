using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Projects
{
    public class AllProjectsPageViewModel : CommonPageViewModel
    {
        public AllProjectsPageViewModel()
        {
            
        }

        public AllProjectsPageViewModel(HeaderViewModel headerViewModel, FooterViewModel footerViewModel) : base(headerViewModel, footerViewModel)
        {
            
        }
        
        public List<ProjectModel> ProjectModels { get; set; }
        
        public ProjectsPageModel ProjectsPageModel { get; set; }
    }
}
