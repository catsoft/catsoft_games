using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories.File
{
    public class CmsFilesRepository<TContext>
        (TContext catsoftContext) : CmsBaseRepository<FileModel, TContext>(catsoftContext), ICmsFilesRepository
        where TContext : DbContext;
}