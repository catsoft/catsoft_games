using System;

namespace App.CMS.ViewModels
{
    public class OneToManySingleImage
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string LinkPropertyName { get; set; }

        public OneToManySingleImage()
        {
            
        }
        public OneToManySingleImage(Guid id, string url, string linkPropertyName)
        {
            Id = id;
            Url = url;
            LinkPropertyName = linkPropertyName;
        }
    }
}
