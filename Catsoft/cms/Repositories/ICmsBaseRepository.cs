using System;
using System.Linq;
using App.cms.Models;

namespace App.cms.Repositories
{
    public interface ICmsBaseRepository<TItem>
        where TItem : class, IEntity
    {
        public void Add(TItem entity);
     
        public void Remove(Guid id);
     
        public void Update(TItem entity);
     
        public TItem Get(Guid id);

        public IQueryable<TItem> GetAll();

        public TItem CreateObject();
    }
}