using App.cms;
using App.cms.Controllers;
using App.cms.FilesHandlers;
using App.cms.ObjectInterceptors;
using App.cms.Repositories.CmsModels;
using App.cms.Repositories.File;
using App.cms.Repositories.Image;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.Models;
using Microsoft.AspNetCore.Hosting;

namespace App.Controllers
{
    public class HomeCmsController(CatsoftContext catsoftContext, IWebHostEnvironment appEnvironment,
            CmsOptions cmsOptions, TypesOptions typesOptions, ICmsImageModelRepository imageRepository,
            ICmsFilesRepository filesRepository, ICmsCmsModelRepository cmsCmsModelRepository, IFileHandler fileHandler,
            IObjectInterceptor objectInterceptor, TextResourceRepository textResourceRepository)
        : HomeCmsController<CatsoftContext>(catsoftContext, appEnvironment, cmsOptions, typesOptions, imageRepository,
            filesRepository, cmsCmsModelRepository, textResourceRepository, objectInterceptor, fileHandler);
}