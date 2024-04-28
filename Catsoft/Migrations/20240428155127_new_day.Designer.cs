﻿// <auto-generated />
using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(CatsoftContext))]
    [Migration("20240428155127_new_day")]
    partial class new_day
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Accounting.AccountModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountModels");
                });

            modelBuilder.Entity("App.Models.Accounting.TransactionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountFromModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountToModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ActualAmount")
                        .HasColumnType("real");

                    b.Property<Guid?>("BillFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillImageModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BillLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForResell")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemplate")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PlannedAmount")
                        .HasColumnType("real");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RecurringEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecurringFrequency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RecurringStart")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TemplateAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("TemplateTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TypeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TypeQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountFromModelId");

                    b.HasIndex("AccountToModelId");

                    b.HasIndex("BillFileId")
                        .IsUnique()
                        .HasFilter("[BillFileId] IS NOT NULL");

                    b.HasIndex("BillImageModelId")
                        .IsUnique()
                        .HasFilter("[BillImageModelId] IS NOT NULL");

                    b.HasIndex("TemplateTransactionId");

                    b.ToTable("TransactionModels");
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

            modelBuilder.Entity("App.Models.ContactsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactsModels");
                });

            modelBuilder.Entity("App.Models.EmailRecordModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailRecordsModels");
                });

            modelBuilder.Entity("App.Models.EventModel", b =>
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

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique()
                        .HasFilter("[ImageModelId] IS NOT NULL");

                    b.ToTable("EventsModels");
                });

            modelBuilder.Entity("App.Models.ExperienceModel", b =>
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

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique()
                        .HasFilter("[ImageModelId] IS NOT NULL");

                    b.ToTable("ExperiencesModels");
                });

            modelBuilder.Entity("App.Models.GameModel", b =>
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

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique()
                        .HasFilter("[ImageModelId] IS NOT NULL");

                    b.ToTable("GameModels");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArticleModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EventModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExperienceModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GameModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MainPageModelGalleryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid?>("ServiceModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TransactionModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainPageModelGalleryId");

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

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.BookPageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookHtml")
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

                    b.ToTable("BookPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.ContactsPageModel", b =>
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

                    b.Property<string>("Title")
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

                    b.ToTable("MainPageModels");
                });

            modelBuilder.Entity("App.Models.Pages.PreOrderPageModel", b =>
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

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("PreOrderLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreOrderText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreOrderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PreOrderPageModels");
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

            modelBuilder.Entity("App.Models.PreOrderModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId")
                        .IsUnique()
                        .HasFilter("[ImageModelId] IS NOT NULL");

                    b.ToTable("ServiceModels");
                });

            modelBuilder.Entity("App.cms.Models.AdminModel", b =>
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminModels");
                });

            modelBuilder.Entity("App.cms.Models.CmsModel", b =>
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CmsModels");
                });

            modelBuilder.Entity("App.cms.Models.FileModel", b =>
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

                    b.Property<Guid?>("TransactionModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("App.cms.Models.TextResourceModel", b =>
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

            modelBuilder.Entity("App.cms.Models.TextResourceValueModel", b =>
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

                    b.ToTable("TextResourceValuesModels");
                });

            modelBuilder.Entity("App.Models.Accounting.TransactionModel", b =>
                {
                    b.HasOne("App.Models.Accounting.AccountModel", "AccountFromModel")
                        .WithMany("TransactionFromModels")
                        .HasForeignKey("AccountFromModelId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("App.Models.Accounting.AccountModel", "AccountToModel")
                        .WithMany("TransactionToModels")
                        .HasForeignKey("AccountToModelId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("App.cms.Models.FileModel", "BillFile")
                        .WithOne("TransactionModel")
                        .HasForeignKey("App.Models.Accounting.TransactionModel", "BillFileId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("App.Models.ImageModel", "BillImageModel")
                        .WithOne("TransactionModel")
                        .HasForeignKey("App.Models.Accounting.TransactionModel", "BillImageModelId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("App.Models.Accounting.TransactionModel", "TemplateTransaction")
                        .WithMany("ActualTransactions")
                        .HasForeignKey("TemplateTransactionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AccountFromModel");

                    b.Navigation("AccountToModel");

                    b.Navigation("BillFile");

                    b.Navigation("BillImageModel");

                    b.Navigation("TemplateTransaction");
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

            modelBuilder.Entity("App.Models.EventModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("EventModel")
                        .HasForeignKey("App.Models.EventModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.Models.ExperienceModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("ExperienceModel")
                        .HasForeignKey("App.Models.ExperienceModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.Models.GameModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("GameModel")
                        .HasForeignKey("App.Models.GameModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.HasOne("App.Models.Pages.MainPageModel", "MainPageModelGallery")
                        .WithMany("Images")
                        .HasForeignKey("MainPageModelGalleryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MainPageModelGallery");
                });

            modelBuilder.Entity("App.Models.ServiceModel", b =>
                {
                    b.HasOne("App.Models.ImageModel", "ImageModel")
                        .WithOne("ServiceModel")
                        .HasForeignKey("App.Models.ServiceModel", "ImageModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("App.cms.Models.TextResourceValueModel", b =>
                {
                    b.HasOne("App.cms.Models.TextResourceModel", "TextResourceModel")
                        .WithMany("Values")
                        .HasForeignKey("TextResourceModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("TextResourceModel");
                });

            modelBuilder.Entity("App.Models.Accounting.AccountModel", b =>
                {
                    b.Navigation("TransactionFromModels");

                    b.Navigation("TransactionToModels");
                });

            modelBuilder.Entity("App.Models.Accounting.TransactionModel", b =>
                {
                    b.Navigation("ActualTransactions");
                });

            modelBuilder.Entity("App.Models.ArticleModel", b =>
                {
                    b.Navigation("CommentModels");
                });

            modelBuilder.Entity("App.Models.ImageModel", b =>
                {
                    b.Navigation("ArticleModel");

                    b.Navigation("EventModel");

                    b.Navigation("ExperienceModel");

                    b.Navigation("GameModel");

                    b.Navigation("ServiceModel");

                    b.Navigation("TransactionModel");
                });

            modelBuilder.Entity("App.Models.Pages.MainPageModel", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("App.cms.Models.FileModel", b =>
                {
                    b.Navigation("TransactionModel");
                });

            modelBuilder.Entity("App.cms.Models.TextResourceModel", b =>
                {
                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
