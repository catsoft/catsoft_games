using System.Collections.Generic;
using System.IO;
using System.Linq;
using App.cms.Models;
using App.Models;
using App.ViewModels.About;
using App.ViewModels.Contacts;
using App.ViewModels.Games;
using App.ViewModels.Home;
using App.ViewModels.Services;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ImageModel = App.Models.ImageModel;

namespace App.Controllers
{
    public class HomeController : CommonController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(CatsoftContext catsoftContext, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var home = new HomePageViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                ContactsPageViewModel = new ContactsPageViewModel(CatsoftContext.ContactsPageModels
                    .FirstOrDefault(), CatsoftContext.ContactsModels.ToList()),
                Page = CatsoftContext.MainPageModels
                    .Include(w => w.Images)
                    .FirstOrDefault(),
                AboutPageViewModel = new AboutPageViewModel(CatsoftContext.AboutPageModels.FirstOrDefault()),
                ServicesPageViewModel = new ServicesPageViewModel(CatsoftContext.ServicesPageModels.FirstOrDefault()),
            };

            var services = CatsoftContext.ServiceModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(home.Page?.ServicesCount ?? 0)
                .ToList();

            var games = CatsoftContext.GameModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .ToList();

            home.ServicesPageViewModel.ServiceModels = services;

            home.GamesViewModel = new GamesViewModel()
            {
                GameModels = games
            };

            home.HeaderViewModel.CurrentPage = Menu.Home;

            return View(home);
        }

        public IActionResult CleanImages()
        {
            CleanImagesWithoutReferences();
            
            CleanImagesWithoutEntity();
            
            GenerateImagesWithoutOriginalPath();
            
            return RedirectToAction("Index");
        }

        private void CleanImagesWithoutReferences()
        {
            var images = CatsoftContext.Images.ToList();

            var servicesImages = CatsoftContext.ServiceModels.Include(w => w.ImageModel).Select(w => w.ImageModel).ToList();
            var articleImages = CatsoftContext.ArticleModels.Include(w => w.ImageModel).Select(w => w.ImageModel).ToList();
            var imagesWithReferences =
                images.Where(w => w.MainPageModelGalleryId != null).ToList();

            var allImagesIds = new List<List<ImageModel>>()
            {
                servicesImages, articleImages, imagesWithReferences
            }.SelectMany(w => w).Where(w => w != null).Select(w => w.Id).ToList();

            foreach (var imageModel in images)
            {
                if (!allImagesIds.Contains(imageModel.Id))
                {
                    CatsoftContext.Remove(imageModel);
                }
            }

            CatsoftContext.SaveChanges();
        }

        private void CleanImagesWithoutEntity()
        {
            var images = CatsoftContext.Images.ToList();

            var pathes = images.SelectMany(w => new string[] {w.Url, w.OriginalUrl}).ToList();

            var files = Directory.GetFiles(_webHostEnvironment.WebRootPath + "/UploadImages/");

            foreach (var file in files)
            {
                if (pathes.All(w => !file.Contains(w)))
                {
                    System.IO.File.Delete(file);
                }
            }
        }

        protected void GenerateImagesWithoutOriginalPath()
        {
            var images = CatsoftContext.Images.ToList();

            var allImagesWithoutCompressed = images.Where(w => string.IsNullOrEmpty(w.OriginalUrl)).ToList();
            
            foreach (var imageModel in allImagesWithoutCompressed)
            {
                var originalExtension = Path.GetExtension(imageModel.Url);
                var original = GetOriginalPath(imageModel, originalExtension);
                var compressedUrl = GetCompressedPath(imageModel, "webp");

                var oldUrl = imageModel.Url;

                if (string.IsNullOrEmpty(oldUrl) || !System.IO.File.Exists(_webHostEnvironment.WebRootPath + oldUrl))
                {
                    CatsoftContext.Images.Remove(imageModel);
                    CatsoftContext.SaveChanges();
                    continue;
                }
                
                SaveCompressedImage(oldUrl, compressedUrl, original);

                imageModel.Url = compressedUrl;
                imageModel.OriginalUrl = original;
                CatsoftContext.Images.Update(imageModel);
                CatsoftContext.SaveChanges();
            }
        }
        
        private string GetCompressedPath(IEntity imageModel, string extension) => "/UploadImages/" + imageModel.Id + "_compressed." + extension;
        private string GetOriginalPath(IEntity imageModel, string extension) => "/UploadImages/" + imageModel.Id + "_original." + extension;
        
        private void SaveCompressedImage(string formFile, string compressedPath, string originalPath)
        {
            var streamReader = System.IO.File.OpenRead(_webHostEnvironment.WebRootPath + formFile);
            
            using (var webPFileStream = new FileStream(_webHostEnvironment.WebRootPath + compressedPath, FileMode.Create))
            {
                using (var imageFactory = new ImageFactory())
                {
                    imageFactory.Load(streamReader)
                        .AutoRotate()
                        .Format(new WebPFormat())
                        .Quality(60)
                        .Save(webPFileStream);
                }
            }
            
            streamReader.CopyTo(System.IO.File.OpenWrite(_webHostEnvironment.WebRootPath + originalPath));
        }
    }
}
