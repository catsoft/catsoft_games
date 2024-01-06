using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Projects
{
    public class ProjectsPageViewModel : PartialPageViewModel<ProjectsPageModel>
    {
        public ProjectsPageViewModel()
        {

        }

        public ProjectsPageViewModel(ProjectsPageModel projectsPageModel) : base(projectsPageModel)
        {

        }
        
        public List<ProjectModel> ProjectModels { get; set; }
    }
}