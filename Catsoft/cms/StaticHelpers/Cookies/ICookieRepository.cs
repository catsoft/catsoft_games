using System;
using System.Threading.Tasks;

namespace App.cms.StaticHelpers.Cookies
{
    public interface ICookieRepository<T>
    {
        string Key { get; }
        
        void SaveValue(T value);

        public Task<B> GetWithUpdate<B>(Func<T, Task<B>> action);
        
        T GetValue();

        void Clear();
    }
}