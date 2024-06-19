using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;
using App.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories
{
    public abstract class CmsBaseRepository<TItem, TContext>(TContext catsoftContext) : ICmsBaseRepository<TItem>
        where TItem : class, IEntity
        where TContext : DbContext
    {
        protected TContext CatsoftContext { get; } = catsoftContext;

        public async Task<TItem> GetDefault(Guid? uuid)
        {
            var item = await GetAsync(uuid);
            if (item == null)
            {
                var newObject = CreateObject();
                catsoftContext.Add(newObject);
                await catsoftContext.SaveChangesAsync();
                return newObject;
            }

            return item;
        }
        
        public async Task<TItem> DoWithUpdate(Guid? uuid, Func<TItem, Task> doJob)
        {
            var item = await GetDefault(uuid);
            await doJob(item);
            catsoftContext.Update(item);
            await catsoftContext.SaveChangesAsync();
            return item;
        }
        
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

        public virtual async Task UpdateAsync(TItem entity)
        {
            CatsoftContext.Update(entity);
            await CatsoftContext.SaveChangesAsync();
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

        public Task<TItem> GetAsync(Guid? id)
        {
            return CatsoftContext.Set<TItem>().FirstOrDefaultAsync(w => w.Id == id);
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