using System;
using System.Linq;
using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories
{
    public abstract class CmsBaseRepository<TItem, TContext>(TContext catsoftContext) : ICmsBaseRepository<TItem>
        where TItem : class, IEntity
        where TContext : DbContext
    {
        protected TContext CatsoftContext { get; } = catsoftContext;

        public virtual void Add(TItem entity)
        {
            CatsoftContext.Add(entity);
            CatsoftContext.SaveChanges();
        }

        public virtual void Remove(Guid id)
        {
            CatsoftContext.Remove(Get(id));
            CatsoftContext.SaveChanges();
        }

        public virtual void Update(TItem entity)
        {
            CatsoftContext.Update(entity);
            CatsoftContext.SaveChanges();
        }

        public virtual TItem Get(Guid id)
        {
            return CatsoftContext.Set<TItem>().First(w => w.Id == id);
        }

        public IQueryable<TItem> GetAll()
        {
            return CatsoftContext.Set<TItem>().AsQueryable();
        }

        public virtual TItem CreateObject()
        {
            return Activator.CreateInstance<TItem>();
        }
    }
}