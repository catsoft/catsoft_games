using App.Models;
using App.ViewModels.Common;

namespace App.ViewModels.Projects
{
    public class ProjectPageViewModel : CommonPageViewModel<ProjectModel>
    {
        public ProjectPageViewModel()
        {
            
        }

        public ProjectPageViewModel(ProjectModel page, HeaderViewModel headerViewModel, FooterViewModel footerViewModel) 
            : base(page, headerViewModel, footerViewModel)
        {
            
        }
    }
}