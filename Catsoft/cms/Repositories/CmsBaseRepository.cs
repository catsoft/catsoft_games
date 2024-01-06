using System;
using System.Linq;
using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories
{
    public abstract class CmsBaseRepository<TItem, TContext> : ICmsBaseRepository<TItem>
        where TItem : class, IEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }

        protected CmsBaseRepository(TContext context)
        {
            Context = context;
        }

        public virtual void Add(TItem entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Remove(Guid id)
        {
            Context.Remove(Get(id));
            Context.SaveChanges();
        }

        public virtual void Update(TItem entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public virtual TItem Get(Guid id)
        {
            return Context.Set<TItem>().First(w => w.Id == id);
        }

        public IQueryable<TItem> GetAll()
        {
            return Context.Set<TItem>().AsQueryable();
        }

        public virtual TItem CreateObject()
        {
            return Activator.CreateInstance<TItem>();
        }
    }
}