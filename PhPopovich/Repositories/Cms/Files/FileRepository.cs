using App.CMS.Repositories.File;
using App.Models;

namespace App.Repositories.Cms.Files
{
    public class FileRepository : CmsFilesRepository<Context>
    {
        public FileRepository(Context context) : base(context)
        {
        }
    }
}