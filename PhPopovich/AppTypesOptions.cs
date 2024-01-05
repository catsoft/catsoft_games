using System;
using System.Collections.Generic;
using System.Linq;
using App.CMS.StaticHelpers;
using App.Models;

namespace App
{
    public class AppTypesOptions : TypesOptions
    {
        public override Type ListImage { get; } = typeof(List<ImageModel>);

        public override Type Image { get; } = typeof(ImageModel);

        public override List<CMS.Models.ImageModel> CastToImage(dynamic _object)
        {
            return (_object as List<ImageModel> ?? new List<ImageModel>()).Cast<CMS.Models.ImageModel>().ToList();
        }
    }
}