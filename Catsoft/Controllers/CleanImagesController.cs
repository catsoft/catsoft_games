using App.cms.StaticHelpers.Cookies;
using App.Models;
using Microsoft.AspNetCore.Hosting;

namespace App.Controllers
{
    public class CleanImagesController : CommonController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CleanImagesController(CatsoftContext dbContext, IWebHostEnvironment webHostEnvironment,
            ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            DbContext = dbContext;
        }

        // выключил на случай если нечайно ебну
        // public IActionResult CleanImages()
        // {
        //     CleanImagesWithoutReferences();
        //
        //     CleanImagesWithoutEntity();
        //
        //     GenerateImagesWithoutOriginalPath();
        //
        //     return RedirectToAction("Index");
        // }

        // private void CleanImagesWithoutReferences()
        // {
        //     var images = CatsoftContext.Images.ToList();
        //
        //     var servicesImages = CatsoftContext.ServiceModels.Include(w => w.ImageModel).Select(w => w.ImageModel)
        //         .ToList();
        //     var articleImages = CatsoftContext.ArticleModels.Include(w => w.ImageModel).Select(w => w.ImageModel)
        //         .ToList();
        //     var imagesWithReferences =
        //         images.Where(w => w.MainPageModelGalleryId != null).ToList();
        //
        //     var allImagesIds = new List<List<ImageModel>>
        //     {
        //         servicesImages, articleImages, imagesWithReferences
        //     }.SelectMany(w => w).Where(w => w != null).Select(w => w.Id).ToList();
        //
        //     foreach (var imageModel in images)
        //     {
        //         if (!allImagesIds.Contains(imageModel.Id))
        //         {
        //             CatsoftContext.Remove(imageModel);
        //         }
        //     }
        //
        //     CatsoftContext.SaveChanges();
        // }
        //
        // private void CleanImagesWithoutEntity()
        // {
        //     var images = CatsoftContext.Images.ToList();
        //
        //     var pathes = images.SelectMany(w => new[] { w.Url, w.OriginalUrl }).ToList();
        //
        //     var files = Directory.GetFiles(_webHostEnvironment.WebRootPath + "/UploadImages/");
        //
        //     foreach (var file in files)
        //     {
        //         if (pathes.All(w => !file.Contains(w)))
        //         {
        //             System.IO.File.Delete(file);
        //         }
        //     }
        // }
        //
        // protected void GenerateImagesWithoutOriginalPath()
        // {
        //     var images = CatsoftContext.Images.ToList();
        //
        //     var allImagesWithoutCompressed = images.Where(w => string.IsNullOrEmpty(w.OriginalUrl)).ToList();
        //
        //     foreach (var imageModel in allImagesWithoutCompressed)
        //     {
        //         var originalExtension = Path.GetExtension(imageModel.Url);
        //         var original = GetOriginalPath(imageModel, originalExtension);
        //         var compressedUrl = GetCompressedPath(imageModel, "webp");
        //
        //         var oldUrl = imageModel.Url;
        //
        //         if (string.IsNullOrEmpty(oldUrl) || !System.IO.File.Exists(_webHostEnvironment.WebRootPath + oldUrl))
        //         {
        //             CatsoftContext.Images.Remove(imageModel);
        //             CatsoftContext.SaveChanges();
        //             continue;
        //         }
        //
        //         SaveCompressedImage(oldUrl, compressedUrl, original);
        //
        //         imageModel.Url = compressedUrl;
        //         imageModel.OriginalUrl = original;
        //         CatsoftContext.Images.Update(imageModel);
        //         CatsoftContext.SaveChanges();
        //     }
        // }
        //
        // private string GetCompressedPath(IEntity imageModel, string extension)
        // {
        //     return "/UploadImages/" + imageModel.Id + "_compressed." + extension;
        // }
        //
        // private string GetOriginalPath(IEntity imageModel, string extension)
        // {
        //     return "/UploadImages/" + imageModel.Id + "_original." + extension;
        // }
        //
        // private void SaveCompressedImage(string formFile, string compressedPath, string originalPath)
        // {
        //     var streamReader = System.IO.File.OpenRead(_webHostEnvironment.WebRootPath + formFile);
        //
        //     using (var webPFileStream =
        //            new FileStream(_webHostEnvironment.WebRootPath + compressedPath, FileMode.Create))
        //     {
        //         using (var imageFactory = new ImageFactory())
        //         {
        //             imageFactory.Load(streamReader)
        //                 .AutoRotate()
        //                 .Format(new WebPFormat())
        //                 .Quality(60)
        //                 .Save(webPFileStream);
        //         }
        //     }
        //
        //     streamReader.CopyTo(System.IO.File.OpenWrite(_webHostEnvironment.WebRootPath + originalPath));
        // }
    }
}