
namespace App.Models.Pages
{
    public interface IMetaInfo
    {
        string MetaTitle { get; set; }
        
        string MetaDescription { get; set; }
        
        string KeyWords { get; set; }
                
        ImageModel MetaImageModel { get; set; }
    }
}