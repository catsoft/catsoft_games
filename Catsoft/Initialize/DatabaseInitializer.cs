using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.CMS.Models;
using App.Models;
using App.Models.Pages;

namespace App.Initialize
{
    public class DatabaseInitializer
    {
        private readonly DatabaseCleaner _cleaner;
        private readonly Context _context;

        public DatabaseInitializer(Context context, DatabaseCleaner cleaner)
        {
            _context = context;
            _cleaner = cleaner;
        }

        public void Init()
        {
            // _cleaner.Clean();

            if (!_context.AdminModels.Any())
            {
                var defaultAdmin = new AdminModel
                {
                    Login = "admin",
                    Password = "admin",
                    Title = "Default Admin"
                };

                _context.Add(defaultAdmin);
            }

            if (!_context.MainPageModels.Any())
            {
                var mainModels = new List<MainPageModel>
                {
                    new MainPageModel
                    {
                        Title = "Main Page",
                    }
                };

                _context.AddRange(mainModels);
            }

            _context.SaveChanges();


            if (!_context.CmsModels.Any())
            {
                var types = Assembly.GetAssembly(typeof(Entity<>))?.GetTypes() ?? Type.EmptyTypes;

                var classes = types.Where(w => w.FullName.Contains(".Models.") && w.Name.EndsWith("Model")).ToList();

                var cmsModels = classes.OrderBy(w => !w.Name.Contains("Page")).Select((w, i) => new CmsModel
                {
                    Title = w.Name.Replace("Model", ""),
                    Class = w.FullName,
                    Position = i,
                    IsSinglePage = w.Name.Contains("Page"),
                    NewCount = 0,
                }).ToList();

                _context.AddRange(cmsModels);

                _context.SaveChanges();

                var pages = classes.Where(w => w.Name.Contains("Page")).ToList();
                foreach (var page in pages)
                {
                    var pageObject = Activator.CreateInstance(page);
                    if (pageObject != null)
                    {
                        _context.Add(pageObject);
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}