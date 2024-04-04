using System;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.EntityFrameworkPaginateCore;
using App.cms.Models;
using App.Models.Pages;

namespace App.Models
{
    [Access(false, true, false)]
    public class ImageModel : Entity<ImageModel>, ISortFilterEntity<ImageModel>
    {
        [DataType(DataType.ImageUrl)] public string Url { get; set; }

        [DataType(DataType.ImageUrl)] public string OriginalUrl { get; set; }

        public string ImageType { get; set; }

        public string Extension { get; set; }


        [Show(false, false, false, false)] public Guid? MainPageModelGalleryId { get; set; }

        [Show(false, false, false, false)] public MainPageModel MainPageModelGallery { get; set; }


        [Show(false, false, false, false)] public Guid? ServiceModelId { get; set; }

        [Show(false, false, false, false)] public ServiceModel ServiceModel { get; set; }


        [Show(false, false, false, false)] public Guid? GameModelId { get; set; }

        [Show(false, false, false, false)] public GameModel GameModel { get; set; }


        [Show(false, false, false, false)] public Guid? EventModelId { get; set; }

        [Show(false, false, false, false)] public EventModel EventModel { get; set; }


        [Show(false, false, false, false)] public Guid? ExperienceModelId { get; set; }

        [Show(false, false, false, false)] public ExperienceModel ExperienceModel { get; set; }


        [Show(false, false, false, false)] public Guid? ArticleModelId { get; set; }

        [Show(false, false, false, false)] public ArticleModel ArticleModel { get; set; }


        Filters<ImageModel> ISortFilterEntity<ImageModel>.GetDefaultFilters(params string[] filters)
        {
            var filter = new Filters<ImageModel>();
            return filter;
        }

        Sorts<ImageModel> ISortFilterEntity<ImageModel>.GetDefaultSorted()
        {
            var sorted = new Sorts<ImageModel>();
            return sorted;
        }
    }
}