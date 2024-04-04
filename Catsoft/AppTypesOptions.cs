using System;
using System.Collections.Generic;
using System.Linq;
using App.cms.StaticHelpers;
using App.Models;

namespace App
{
    public class AppTypesOptions : TypesOptions
    {
        public override Type ListImage { get; } = typeof(List<ImageModel>);

        public override Type Image { get; } = typeof(ImageModel);

        public override List<ImageModel> CastToImage(dynamic _object)
        {
            return (_object as List<ImageModel> ?? new List<ImageModel>()).ToList();
        }
    }
}