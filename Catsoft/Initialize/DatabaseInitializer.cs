using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.CMS.Models;
using App.Models;
using App.Models.Pages;
using Microsoft.Extensions.Logging;

namespace App.Initialize
{
    public class DatabaseInitializer(CatsoftContext catsoftContext, DatabaseCleaner cleaner)
    {
        public void Init()
        {
            cleaner.Clean();

            if (!catsoftContext.AdminModels.Any())
            {
                var defaultAdmin = new AdminModel
                {
                    Login = "admin",
                    Password = "admin",
                    Title = "Default Admin"
                };

                catsoftContext.Add(defaultAdmin);
            }

            if (!catsoftContext.MainPageModels.Any())
            {
                var mainModels = new List<MainPageModel>
                {
                    new()
                    {
                        Title = "Home Page"
                    }
                };

                catsoftContext.AddRange(mainModels);
            }

            catsoftContext.SaveChanges();


            if (!catsoftContext.CmsModels.Any())
            {
                var types = Assembly.GetAssembly(typeof(Entity<>))?.GetTypes() ?? Type.EmptyTypes;

                var classes = types.Where(w => w.FullName.Contains(".Models.") && w.Name.EndsWith("Model")).ToList();

                var cmsModels = classes.OrderBy(w => !w.Name.Contains("Page")).Select((w, i) => new CmsModel
                {
                    Title = w.Name.Replace("Model", ""),
                    Class = w.FullName,
                    Position = i,
                    IsSinglePage = w.Name.Contains("Page"),
                    NewCount = 0
                }).ToList();

                catsoftContext.AddRange(cmsModels);

                catsoftContext.SaveChanges();

                var pages = classes.Where(w => w.Name.Contains("Page")).ToList();
                foreach (var page in pages)
                {
                    var pageObject = Activator.CreateInstance(page);
                    if (pageObject != null)
                    {
                        catsoftContext.Add(pageObject);
                        catsoftContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"Can't create page object {page.FullName}");
                    }
                }
            }

            if (!catsoftContext.Menus.Any())
            {
                var menuObjects = Enum.GetValues(typeof(Menu)).Cast<Menu>().ToList().Select((w, i) =>
                    new MenuModel
                    {
                        Name = w.ToString(),
                        Href = MenuLinks.links.FirstOrDefault(q => q.Key == w).Value,
                        Menu = w,
                        Position = i
                    }
                );
                catsoftContext.AddRange(menuObjects);
                catsoftContext.SaveChanges();
            }

            catsoftContext.SaveChanges();
        }
    }
}