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
        public ProjectController(Context context)
        {
            Context = context;
        }

        public IActionResult Index(Guid id)
        {
            var page = Context.ProjectModels
                .Include(w => w.ImageModel)
                .Include(w => w.Images)
                .FirstOrDefault(w => w.Id == id);
            
            var projects = new ProjectPageViewModel(page, GetHeaderViewModel(), GetFooterViewModel());

            return View(projects);
        }
    }
}