namespace App.Models.Pages
{
    public class SimpleMetaInfo : IMetaInfo
    {
        public string MetaTitle { get; set; }
        
        public string MetaDescription { get; set; }
        
        public string KeyWords { get; set; }

        public ImageModel MetaImageModel { get; set; }
    }
}