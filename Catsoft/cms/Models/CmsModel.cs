using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access]
    public class CmsModel : Entity<CmsModel>
    {
        [Show] public override string Title { get; set; }

        [Show] public override int Position { get; set; }

        [Show] public string Class { get; set; }

        [Show] public int NewCount { get; set; }

        [Show] public bool IsSinglePage { get; set; }

        public AdminRoles Role { get; set; }

        public string GetPrefix()
        {
            if (!Title.Contains("]"))
            {
                return "";
            }

            return Title.Split('[', ']')[1];
        }
    }
}