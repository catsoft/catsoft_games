using System;
using System.Linq.Expressions;

namespace App.cms.EntityFrameworkPaginateCore
{
    internal class Sort<T, TKey>
    {
        public bool Condition { get; set; }
        public Expression<Func<T, TKey>> Expression { get; set; }
        public bool ByDescending { get; set; }
    }
}