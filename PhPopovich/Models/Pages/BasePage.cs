using System.ComponentModel;
using App.CMS.Models;

namespace App.Models.Pages
{
    public abstract class BasePage<T> : Entity<T>, IPage
        where T : IEntity
    {
        [DisplayName("Заголовок")]
        public virtual string PageTitle { get; set; }
    }
}
