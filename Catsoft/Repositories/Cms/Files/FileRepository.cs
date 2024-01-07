using App.cms.Repositories.File;
using App.Models;

namespace App.Repositories.Cms.Files
{
    public class FileRepository(CatsoftContext catsoftContext) : CmsFilesRepository<CatsoftContext>(catsoftContext);
}