using App.cms.Models;

namespace App.cms.ObjectInterceptors
{
    public interface IObjectInterceptor
    {
        public void Intercept(object obj);
    }

    public interface IObjectInterceptor<T>
        where T : IEntity
    {
        public void Intercept(T obj);
    }
}