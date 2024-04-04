using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Pages
{
    public abstract class MetaBasePage<T> : BasePage<T>, IMetaInfo
        where T : IEntity
    {
        [Show(false)] public virtual string MetaTitle { get; set; }

        [Show(false)] public virtual string MetaDescription { get; set; }


        [Show(false)] public virtual string KeyWords { get; set; }
    }
}