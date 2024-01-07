using System;
using System.Collections.Generic;
using App.CMS.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Initialize
{
    public class DatabaseCleaner(CatsoftContext catsoftContext)
    {
        public void Clean()
        {
            try
            {
                TryRemove(catsoftContext.AdminModels);
                TryRemove(catsoftContext.AboutPageModels);
                TryRemove(catsoftContext.CmsModels);
                TryRemove(catsoftContext.ArticleModels);
                TryRemove(catsoftContext.BlogPageModels);
                TryRemove(catsoftContext.CommentModels);
                TryRemove(catsoftContext.ContactsPageModels);
                TryRemove(catsoftContext.EmailModels);
                TryRemove(catsoftContext.Files);
                TryRemove(catsoftContext.Images);
                TryRemove(catsoftContext.MainPageModels);
                TryRemove(catsoftContext.Menus);
                TryRemove(catsoftContext.OrderModels);
                TryRemove(catsoftContext.PhoneModels);
                TryRemove(catsoftContext.ProjectsPageModels);
                TryRemove(catsoftContext.ServiceModels);
                TryRemove(catsoftContext.ServicesPageModels);
                // TryRemove(_catsoftContext.TextResourceModels);
                // TryRemove(_catsoftContext.TextResourceValuesModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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