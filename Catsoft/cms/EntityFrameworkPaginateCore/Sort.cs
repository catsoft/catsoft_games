using System;
using System.Linq.Expressions;

namespace App.CMS.EntityFrameworkPaginateCore
{
    internal class Sort<T, TKey>
    {
        public bool Condition { get; set; }
        public Expression<Func<T, TKey>> Expression { get; set; }
        public bool ByDescending { get; set; }
    }
}
