using System.Linq;
using App.Models;
using App.ViewModels.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class AllProjectsController : CommonController
    {
        public AllProjectsController(Context context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var allProjects = new AllProjectsPageViewModel(GetHeaderViewModel(), GetFooterViewModel());
            allProjects.HeaderViewModel.CurrentPage = Menu.Projects;
            allProjects.ProjectsPageModel = Context.ProjectsPageModels.FirstOrDefault();
            
            var projects = Context.ProjectModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .ToList();

            allProjects.ProjectModels = projects;
            
            return View(allProjects);
        }
    }
}