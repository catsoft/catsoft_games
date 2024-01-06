﻿// <auto-generated />
using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(CatsoftContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.CMS.Models.AdminModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminModels");
                });

            modelBuilder.Entity("App.CMS.Models.CmsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSinglePage")
                        .HasColumnType("bit");

                    b.Property<int>("NewCount")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CmsModels");
                });

            modelBuilder.Entity("App.CMS.Models.FileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("App.CMS.Models.TextResourceModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TextResourceModels");
                });

            modelBuilder.Entity("App.CMS.Models.TextResourceValueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid?>("TextResourceModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TextResourceModelId");

                    b.ToTable("TextResources");
                });

            modelBuilder.Entity("App.Models.ArticleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique()
                        .HasFilter("[ImageModelId] IS NOT NULL");

                    b.ToTable("ArticleModels");
                });

            modelBuilder.Entity("App.Models.CommentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArticleModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleModelId");

                    b.ToTable("CommentModels");
                });

            modelBuilder.Entity("App.Models.EmailModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactsPageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactsPageModelId");

                    b.ToTable("EmailModels");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArticleModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogPageModelMetaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MainPageModelGalleryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MainPageModelMetaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProjectModelGalleryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainPageModelGalleryId");

                    b.HasIndex("ProjectModelGalleryId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("App.Models.MenuModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Href")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Menu")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("App.Models.OrderModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DesireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailOrPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderModels");
                });

            modelBuilder.Entity("App.Models.Pages.AboutPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AboutHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AboutPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.BlogPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MetaImageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MetaImageModelId")
                        .IsUnique()
                        .HasFilter("[MetaImageModelId] IS NOT NULL");

                    b.ToTable("BlogPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.ContactsPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstaLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VkLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactsPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.MainPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MetaImageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsCount")
                        .HasColumnType("int");

                    b.Property<int>("ServicesCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MetaImageModelId")
                        .IsUnique()
                        .HasFilter("[MetaImageModelId] IS NOT NULL");

                    b.ToTable("MainPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.ProjectsPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("ServicesText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectsPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.ServicesPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("ServicesText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServicesPageModels");
                });

            modelBuilder.Entity("App.Models.PhoneModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactsPageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactsPageModelId");

                    b.ToTable("PhoneModels");
                });

            modelBuilder.Entity("App.Models.ProjectModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageModelId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique();

                    b.ToTable("ProjectModels");
                });

            modelBuilder.Entity("App.Models.ServiceModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageModelId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique();

                    b.ToTable("ServiceModels");
                });

            modelBuilder.Entity("App.CMS.Models.TextResourceValueModel", b =>
                {
                    b.HasOne("App.CMS.Models.TextResourceModel", "TextResourceModel")
                        .WithMany("Values")
                        .HasForeignKey("TextResourceModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("TextResourceModel");
                });

            modelBuilder.Entity("App.Models.ArticleModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("ArticleModel")
                        .HasForeignKey("App.Models.ArticleModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.Models.CommentModel", b =>
                {
                    b.HasOne("App.Models.ArticleModel", "ArticleModel")
                        .WithMany("CommentModels")
                        .HasForeignKey("ArticleModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ArticleModel");
                });

            modelBuilder.Entity("App.Models.EmailModel", b =>
                {
                    b.HasOne("App.Models.Pages.ContactsPageModel", "ContactsPageModel")
                        .WithMany("EmailModels")
                        .HasForeignKey("ContactsPageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ContactsPageModel");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.HasOne("App.Models.Pages.MainPageModel", "MainPageModelGallery")
                        .WithMany("Images")
                        .HasForeignKey("MainPageModelGalleryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Models.ProjectModel", "ProjectModelGallery")
                        .WithMany("Images")
                        .HasForeignKey("ProjectModelGalleryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MainPageModelGallery");

                    b.Navigation("ProjectModelGallery");
                });

            modelBuilder.Entity("App.Models.Pages.BlogPageModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "MetaImageModel")
                        .WithOne("BlogPageModelMeta")
                        .HasForeignKey("App.Models.Pages.BlogPageModel", "MetaImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MetaImageModel");
                });

            modelBuilder.Entity("App.Models.Pages.MainPageModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "MetaImageModel")
                        .WithOne("MainPageModelMeta")
                        .HasForeignKey("App.Models.Pages.MainPageModel", "MetaImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MetaImageModel");
                });

            modelBuilder.Entity("App.Models.PhoneModel", b =>
                {
                    b.HasOne("App.Models.Pages.ContactsPageModel", "ContactsPageModel")
                        .WithMany("PhoneModels")
                        .HasForeignKey("ContactsPageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ContactsPageModel");
                });

            modelBuilder.Entity("App.Models.ProjectModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("ProjectModel")
                        .HasForeignKey("App.Models.ProjectModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.Models.ServiceModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("ServiceModel")
                        .HasForeignKey("App.Models.ServiceModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.CMS.Models.TextResourceModel", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("App.Models.ArticleModel", b =>
                {
                    b.Navigation("CommentModels");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.Navigation("ArticleModel");

                    b.Navigation("BlogPageModelMeta");

                    b.Navigation("MainPageModelMeta");

                    b.Navigation("ProjectModel");

                    b.Navigation("ServiceModel");
                });

            modelBuilder.Entity("App.Models.Pages.ContactsPageModel", b =>
                {
                    b.Navigation("EmailModels");

                    b.Navigation("PhoneModels");
                });

            modelBuilder.Entity("App.Models.Pages.MainPageModel", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("App.Models.ProjectModel", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
