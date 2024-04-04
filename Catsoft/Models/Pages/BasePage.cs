using App.cms.Models;

namespace App.Models.Pages
{
    public abstract class BasePage<T> : Entity<T>, IPage
        where T : IEntity
    {
        public virtual string PageTitle { get; set; }
    }
}