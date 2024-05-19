using System.Threading.Tasks;
using App.cms.Models;

namespace App.cms.ObjectInterceptors
{
    public interface IObjectInterceptor
    {
        public Task Intercept(object obj);
    }

    public interface IObjectInterceptor<T>
        where T : IEntity
    {
        public Task Intercept(T obj);
    }
}