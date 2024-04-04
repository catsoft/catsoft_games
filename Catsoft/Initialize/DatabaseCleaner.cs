using System;
using App.cms.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Initialize
{
    public class DatabaseCleaner(CatsoftContext catsoftContext)
    {
        public void FullClean()
        {
            TryRemove(catsoftContext.AdminModels);
            TryRemove(catsoftContext.AboutPageModels);
            TryRemove(catsoftContext.CmsModels);
            TryRemove(catsoftContext.ArticleModels);
            TryRemove(catsoftContext.BlogPageModels);
            TryRemove(catsoftContext.CommentModels);
            TryRemove(catsoftContext.ContactsPageModels);
            TryRemove(catsoftContext.Files);
            TryRemove(catsoftContext.Images);
            TryRemove(catsoftContext.MainPageModels);
            TryRemove(catsoftContext.Menus);
            TryRemove(catsoftContext.OrderModels);
            TryRemove(catsoftContext.ServiceModels);
            TryRemove(catsoftContext.ServicesPageModels);
            // TryRemove(_catsoftContext.TextResourceModels);
            // TryRemove(_catsoftContext.TextResourceValuesModels);
        }

        public void CleanMenus()
        {
            TryRemove(catsoftContext.Menus);
        }

        private void TryRemove<T>(DbSet<T> entites)
            where T : class, IEntity
        {
            try
            {
                catsoftContext.RemoveRange(entites);
                catsoftContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}