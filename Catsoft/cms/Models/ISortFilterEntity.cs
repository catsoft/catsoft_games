using App.CMS.EntityFrameworkPaginateCore;

namespace App.CMS.Models
{
    public interface ISortFilterEntity<T> : IEntity 
        where T : IEntity
    {
        Filters<T> GetDefaultFilters(params string[] filters);

        Sorts<T> GetDefaultSorted();
    }
}