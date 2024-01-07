using App.cms.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.File
{
    public class CmsFilesRepository<TContext>
        (TContext catsoftContext) : CmsBaseRepository<FileModel, TContext>(catsoftContext), ICmsFilesRepository
        where TContext : DbContext;
}