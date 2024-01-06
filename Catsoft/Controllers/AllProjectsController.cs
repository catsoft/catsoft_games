using System.Linq;
using App.Models;
using App.ViewModels.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class AllProjectsController : CommonController
    {
        public AllProjectsController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var allProjects = new AllProjectsPageViewModel(GetHeaderViewModel(), GetFooterViewModel());
            allProjects.HeaderViewModel.CurrentPage = Menu.AllProjects;
            allProjects.ProjectsPageModel = CatsoftContext.ProjectsPageModels.FirstOrDefault();
            
            var projects = CatsoftContext.ProjectModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .ToList();

            allProjects.ProjectModels = projects;
            
            return View(allProjects);
        }
    }
}