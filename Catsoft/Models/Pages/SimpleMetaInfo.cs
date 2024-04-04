namespace App.Models.Pages
{
    public class SimpleMetaInfo : IMetaInfo
    {
        public ImageModel MetaImageModel { get; set; }
        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string KeyWords { get; set; }
    }
}