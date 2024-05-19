using System.Linq;
using App.cms.Models;
using App.Models.Accounting;
using App.Models.Booking;
using App.Models.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Models
{
    public class CatsoftContext(DbContextOptions options) : DbContext(options)
    {
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

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.EventModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<EventModel>(w => w.ImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.ExperienceModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<ExperienceModel>(w => w.ImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ImageModel>()
                .HasOne(w => w.GameModel)
                .WithOne(w => w.ImageModel)
                .IsRequired(false)
                .HasForeignKey<GameModel>(w => w.ImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GameModel>()
                .HasMany(w => w.GameTagModels)
                .WithMany(w => w.GameModels);

            OnModelCreatingAccounting(modelBuilder);

            OnModelCreatingBooking(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
        }

        private void OnModelCreatingAccounting(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionModel>()
                .HasOne(w => w.AccountFromModel)
                .WithMany(w => w.TransactionFromModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.AccountFromModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TransactionModel>()
                .HasOne(w => w.AccountToModel)
                .WithMany(w => w.TransactionToModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.AccountToModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TransactionModel>()
                .HasOne(w => w.TemplateTransaction)
                .WithMany(w => w.ActualTransactions)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.TemplateTransactionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TransactionModel>()
                .HasOne(w => w.BillFile)
                .WithOne(w => w.TransactionModel)
                .IsRequired(false)
                .HasForeignKey<TransactionModel>(w => w.BillFileId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransactionModel>()
                .HasOne(w => w.BillImageModel)
                .WithOne(w => w.TransactionModel)
                .IsRequired(false)
                .HasForeignKey<TransactionModel>(w => w.BillImageModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void OnModelCreatingBooking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonBookingModel>()
                .HasOne(w => w.PersonModel)
                .WithMany(w => w.PersonBookingModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.PersonModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointTimeModel>()
                .HasOne(w => w.PersonBookingModel)
                .WithMany(w => w.AppointTimeModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.PersonBookingId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointTimeModel>()
                .HasOne(w => w.RentPlaceModel)
                .WithMany(w => w.AppointTimeModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.RentPlaceModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointRuleModel>()
                .HasOne(w => w.AppointTimeModel)
                .WithMany(w => w.AppointRuleModels)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(w => w.AppointTimeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }


        public IQueryable<T> GetDbSet<T>(T type)
            where T : class
        {
            return Set<T>()?.AsQueryable();
        }

        #region CMS

        public DbSet<FileModel> Files { get; set; }

        public DbSet<AdminModel> AdminModels { get; set; }

        public DbSet<ImageModel> Images { get; set; }

        public DbSet<CmsModel> CmsModels { get; set; }

        public DbSet<MenuModel> Menus { get; set; }

        public DbSet<TextResourceModel> TextResourceModels { get; set; }

        public DbSet<TextResourceValueModel> TextResourceValuesModels { get; set; }

        #endregion

        #region Virtuality

        public DbSet<MainPageModel> MainPageModels { get; set; }

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

        public DbSet<ContactsModel> ContactsModels { get; set; }

        public DbSet<EmailRecordModel> EmailRecordsModels { get; set; }
        public DbSet<GameModel> GameModels { get; set; }

        public DbSet<GameTagModel> GameTagModels { get; set; }

        public DbSet<EventModel> EventsModels { get; set; }

        public DbSet<ExperienceModel> ExperiencesModels { get; set; }

        #endregion


        #region Accounting

        public DbSet<AccountModel> AccountModels { get; set; }

        public DbSet<TransactionModel> TransactionModels { get; set; }

        #endregion


        #region Booking

        public DbSet<RentPlaceModel> RentPlaces { get; set; }

        public DbSet<PersonModel> PersonModels { get; set; }

        public DbSet<PersonBookingModel> PersonBookings { get; set; }

        public DbSet<AppointTimeModel> AppointTimes { get; set; }

        public DbSet<AppointRuleModel> AppointRules { get; set; }

        #endregion
    }
}