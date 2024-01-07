using System.Linq;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.Models.Pages;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class CatsoftContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<FileModel> Files { get; set; }

        public DbSet<AdminModel> AdminModels { get; set; }

        public DbSet<ImageModel> Images { get; set; }

        public DbSet<CmsModel> CmsModels { get; set; }
        
        public DbSet<MainPageModel> MainPageModels { get; set; }
      
        public DbSet<MenuModel> Menus { get; set; }

        public DbSet<AboutPageModel> AboutPageModels { get; set; }

        public DbSet<ServicesPageModel> ServicesPageModels { get; set; }

        public DbSet<ContactsPageModel> ContactsPageModels { get; set; }

        public DbSet<PreOrderPageModel> PreOrderPageModels { get; set; }

        public DbSet<BookPageModel> BookPageModels { get; set; }

        public DbSet<BlogPageModel> BlogPageModels { get; set; }

        public DbSet<ServiceModel> ServiceModels { get; set; }

        public DbSet<PreOrderModel> OrderModels { get; set; }
        
        public DbSet<CommentModel> CommentModels { get; set; }
        
        public DbSet<ArticleModel> ArticleModels { get; set; }

        public DbSet<TextResourceModel> TextResourceModels { get; set; }

        public DbSet<TextResourceValueModel> TextResourceValuesModels { get; set; }

        public DbSet<ContactsModel> ContactsModels { get; set; }

        public DbSet<EmailRecordModel> EmailRecordsModels { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ServiceModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ServiceModel>(w => w.ImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ArticleModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ArticleModel>(w => w.ImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<MainPageModel>()
                .HasMany(w => w.Images)
                .WithOne(w => w.MainPageModelGallery)
                .IsRequired(false)
                .HasForeignKey(w => w.MainPageModelGalleryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ArticleModel>()
                .HasMany(w => w.CommentModels)
                .WithOne(w => w.ArticleModel)
                .IsRequired(false)
                .HasForeignKey(w => w.ArticleModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<TextResourceValueModel>()
                .HasOne(w => w.TextResourceModel)
                .WithMany(w => w.Values)
                .IsRequired(false)
                .HasForeignKey(w => w.TextResourceModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public IQueryable<T> GetDbSet<T>(T type)
            where T : class
        {

            return Set<T>()?.AsQueryable();
        }
    }
}
