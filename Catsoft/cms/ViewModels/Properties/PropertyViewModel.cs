using System.Reflection;

namespace App.cms.ViewModels.Properties
{
    public class PropertyViewModel
    {
        public PropertyViewModel()
        {
        }

        public PropertyViewModel(dynamic model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
        }

        public dynamic Model { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}