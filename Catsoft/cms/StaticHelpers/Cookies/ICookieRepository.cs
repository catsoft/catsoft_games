namespace App.cms.StaticHelpers.Cookies
{
    public interface ICookieRepository<T>
    {
        string Key { get; }
        
        void SaveValue(T value);
        
        T GetValue();
    }
}