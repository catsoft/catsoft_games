using App.CMS;
using App.CMS.Controllers;
using App.CMS.FilesHandlers;
using App.CMS.Repositories.CmsModels;
using App.CMS.Repositories.File;
using App.CMS.Repositories.Image;
using App.CMS.StaticHelpers;
using App.Models;
using Microsoft.AspNetCore.Hosting;

namespace App.Controllers
{
    public class HomeCmsController : HomeCmsController<Context>
    {
        public HomeCmsController(Context context, IWebHostEnvironment appEnvironment, CmsOptions cmsOptions, TypesOptions typesOptions, ICmsImageModelRepository imageRepository, ICmsFilesRepository filesRepository, ICmsCmsModelRepository cmsCmsModelRepository, IFileHandler fileHandler) : base(context, appEnvironment, cmsOptions, typesOptions, imageRepository, filesRepository, cmsCmsModelRepository, fileHandler)
        {
        }
    }
}