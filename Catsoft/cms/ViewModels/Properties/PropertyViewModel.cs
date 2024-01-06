using System.Reflection;

namespace App.CMS.ViewModels.Properties
{
    public class PropertyViewModel
    {
        public dynamic Model { get; set; }
        
        public PropertyInfo PropertyInfo { get; set; }

        public PropertyViewModel()
        {
            
        }

        public PropertyViewModel(dynamic model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
        }
    }
}