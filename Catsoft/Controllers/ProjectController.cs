using System;
using System.Linq;
using App.Models;
using App.ViewModels.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class ProjectController : CommonController
    {
        public ProjectController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index(Guid id)
        {
            var page = CatsoftContext.ProjectModels
                .Include(w => w.ImageModel)
                .Include(w => w.Images)
                .FirstOrDefault(w => w.Id == id);
            
            var projects = new ProjectPageViewModel(page, GetHeaderViewModel(), GetFooterViewModel());

            return View(projects);
        }
    }
}