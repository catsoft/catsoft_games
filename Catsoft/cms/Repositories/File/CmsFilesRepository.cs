using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories.File
{
    public class CmsFilesRepository<TContext>: CmsBaseRepository<FileModel, TContext>, ICmsFilesRepository
    where TContext : DbContext
    {
        public CmsFilesRepository(TContext context) : base(context)
        {
        }
    }
}