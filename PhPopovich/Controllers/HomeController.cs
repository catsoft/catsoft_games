using System.Collections.Generic;
using System.IO;
using System.Linq;
using App.CMS.Models;
using App.Models;
using App.ViewModels.About;
using App.ViewModels.Contacts;
using App.ViewModels.Home;
using App.ViewModels.Projects;
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

        public HomeController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            Context = context;
        }

        public IActionResult Index()
        {
            var home = new HomePageViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                ContactsPageViewModel = new ContactsPageViewModel(Context.ContactsPageModels
                    .Include(w => w.EmailModels)
                    .Include(w => w.PhoneModels)
                    .FirstOrDefault()),
                Page = Context.MainPageModels
                    .Include(w => w.Images)
                    .Include(w => w.MetaImageModel)
                    .FirstOrDefault(),
                AboutPageViewModel = new AboutPageViewModel(Context.AboutPageModels.FirstOrDefault()),
                ServicesPageViewModel = new ServicesPageViewModel(Context.ServicesPageModels.FirstOrDefault()),
                ProjectsPageViewModel = new ProjectsPageViewModel(Context.ProjectsPageModels.FirstOrDefault()),
            };

            var services = Context.ServiceModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(home.Page?.ServicesCount ?? 0)
                .ToList();

            var projects = Context.ProjectModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(home.Page?.ProjectsCount ?? 0)
                .ToList();

            home.ServicesPageViewModel.ServiceModels = services;
            home.ProjectsPageViewModel.ProjectModels = projects;

            home.HeaderViewModel.CurrentPage = Menu.Main;

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
            var images = Context.Images.ToList();

            var servicesImages = Context.ServiceModels.Include(w => w.ImageModel).Select(w => w.ImageModel).ToList();
            var projectImages = Context.ProjectModels.Include(w => w.ImageModel).Select(w => w.ImageModel).ToList();
            var articleImages = Context.ArticleModels.Include(w => w.ImageModel).Select(w => w.ImageModel).ToList();
            var blogPageImages = Context.BlogPageModels.Include(w => w.MetaImageModel).Select(w => w.MetaImageModel)
                .ToList();
            var mainPageMetaImages = Context.MainPageModels.Include(w => w.MetaImageModel).Select(w => w.MetaImageModel)
                .ToList();
            var imagesWithReferences =
                images.Where(w => w.ProjectModelGalleryId != null || w.MainPageModelGalleryId != null).ToList();

            var allImagesIds = new List<List<ImageModel>>()
            {
                servicesImages, projectImages, articleImages, blogPageImages, mainPageMetaImages, imagesWithReferences
            }.SelectMany(w => w).Where(w => w != null).Select(w => w.Id).ToList();

            foreach (var imageModel in images)
            {
                if (!allImagesIds.Contains(imageModel.Id))
                {
                    Context.Remove(imageModel);
                }
            }

            Context.SaveChanges();
        }

        private void CleanImagesWithoutEntity()
        {
            var images = Context.Images.ToList();

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
            var images = Context.Images.ToList();

            var allImagesWithoutCompressed = images.Where(w => string.IsNullOrEmpty(w.OriginalUrl)).ToList();
            
            foreach (var imageModel in allImagesWithoutCompressed)
            {
                var originalExtension = Path.GetExtension(imageModel.Url);
                var original = GetOriginalPath(imageModel, originalExtension);
                var compressedUrl = GetCompressedPath(imageModel, "webp");

                var oldUrl = imageModel.Url;

                if (string.IsNullOrEmpty(oldUrl) || !System.IO.File.Exists(_webHostEnvironment.WebRootPath + oldUrl))
                {
                    Context.Images.Remove(imageModel);
                    Context.SaveChanges();
                    continue;
                }
                
                SaveCompressedImage(oldUrl, compressedUrl, original);

                imageModel.Url = compressedUrl;
                imageModel.OriginalUrl = original;
                Context.Images.Update(imageModel);
                Context.SaveChanges();
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
