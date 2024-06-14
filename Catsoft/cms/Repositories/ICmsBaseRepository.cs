using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;

namespace App.cms.Repositories
{
    public interface ICmsBaseRepository<TItem>
        where TItem : class, IEntity
    {
        public void Add(TItem entity);

        public Task<TItem> GetDefault(Guid? uuid = null);

        public Task<TItem> DoWithUpdate(Guid? uuid, Func<TItem, Task> doJob);
        
        public void Remove(Guid id);

        public void Update(TItem entity);

        public TItem Get(Guid id);

        public IQueryable<TItem> GetAll();

        public TItem CreateObject();
    }
}