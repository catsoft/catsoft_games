using System;
using System.Collections.Generic;
using System.Linq;
using App.cms.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.StaticHelpers
{
    public static class DataHelper
    {
        public static IEnumerable<IEntity> GetList(DbContext dbContext, Type type)
        {
            dynamic instance = Activator.CreateInstance(type);
            return GetDbSet(dbContext, instance);
        }

        // ReSharper disable once UnusedParameter.Local
        private static IQueryable<T> GetDbSet<T>(DbContext dbContext, T type)
            where T : class
        {
            return dbContext.Set<T>()?.AsQueryable();
        }
    }
}