using System.Collections.Generic;

namespace App.Utils
{
    public static class IEnumerableExtension
    {       
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> source)
        {
            return source ?? new List<T>();
        }
    }
}