using System;

namespace App.cms.ViewModels
{
    public class OneToManySingleImage
    {
        public OneToManySingleImage()
        {
        }

        public OneToManySingleImage(Guid id, string url, string linkPropertyName)
        {
            Id = id;
            Url = url;
            LinkPropertyName = linkPropertyName;
        }

        public Guid Id { get; set; }

        public string Url { get; set; }

        public string LinkPropertyName { get; set; }
    }
}