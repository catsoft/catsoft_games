using System;
using System.Collections;
using System.Collections.Generic;
using App.cms.Models;

namespace App.cms.StaticHelpers
{
    public class TypesOptions
    {
        public virtual Type Enumerable { get; } = typeof(IEnumerable);
        
        public virtual Type String { get; } = typeof(string);
        
        public virtual Type Bool { get; } = typeof(bool);
        
        public virtual Type Image { get; } = typeof(ImageModel);
        
        public virtual Type ListImage { get; } = typeof(List<ImageModel>);
        
        public virtual Type File { get; } = typeof(FileModel);

        public virtual List<ImageModel> CastToImage(dynamic _object)
        {
            return _object as List<ImageModel> ?? new List<ImageModel>();
        }
    }
}
