using System.Linq;
using App.CMS.Models;
using App.Models.Pages;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<FileModel> Files { get; set; }

        public DbSet<AdminModel> AdminModels { get; set; }

        public DbSet<ImageModel> Images { get; set; }

        public DbSet<CmsModel> CmsModels { get; set; }
        
        public DbSet<MainPageModel> MainPageModels { get; set; }
      
        public DbSet<MenuModel> Menus { get; set; }

        public DbSet<AboutPageModel> AboutPageModels { get; set; }

        public DbSet<ServicesPageModel> ServicesPageModels { get; set; }

        public DbSet<ProjectsPageModel> ProjectsPageModels { get; set; }

        public DbSet<ContactsPageModel> ContactsPageModels { get; set; }

        public DbSet<BlogPageModel> BlogPageModels { get; set; }

        public DbSet<PhoneModel> PhoneModels { get; set; }

        public DbSet<EmailModel> EmailModels { get; set; }

        public DbSet<ServiceModel> ServiceModels { get; set; }

        public DbSet<ProjectModel> ProjectModels { get; set; }

        public DbSet<OrderModel> OrderModels { get; set; }
        
        public DbSet<CommentModel> CommentModels { get; set; }
        
        public DbSet<ArticleModel> ArticleModels { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhoneModel>()
                .HasOne(w => w.ContactsPageModel)
                .WithMany(w => w.PhoneModels)
                .IsRequired(false)
                .HasForeignKey(w => w.ContactsPageModelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmailModel>()
                .HasOne(w => w.ContactsPageModel)
                .WithMany(w => w.EmailModels)
                .IsRequired(false)
                .HasForeignKey(w => w.ContactsPageModelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ServiceModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ServiceModel>(w => w.ImageModelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ProjectModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ProjectModel>(w => w.ImageModelId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ArticleModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ArticleModel>(w => w.ImageModelId)
                .OnDelete(DeleteBehavior.SetNull);
            
            
            
            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.MainPageModelMeta)
                .WithOne(w => w.MetaImageModel)
                .IsRequired(false)
                .HasForeignKey<MainPageModel>(w => w.MetaImageModelId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.BlogPageModelMeta)
                .WithOne(w => w.MetaImageModel)
                .IsRequired(false)
                .HasForeignKey<BlogPageModel>(w => w.MetaImageModelId)
                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<MainPageModel>()
                .HasMany(w => w.Images)
                .WithOne(w => w.MainPageModelGallery)
                .HasForeignKey(w => w.MainPageModelGalleryId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ProjectModel>()
                .HasMany(w => w.Images)
                .WithOne(w => w.ProjectModelGallery)
                .HasForeignKey(w => w.ProjectModelGalleryId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ArticleModel>()
                .HasMany(w => w.CommentModels)
                .WithOne(w => w.ArticleModel)
                .HasForeignKey(w => w.ArticleModelId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public IQueryable<T> GetDbSet<T>(T type)
            where T : class
        {

            return Set<T>()?.AsQueryable();
        }
    }
}
