using System;

namespace App.CMS.Controllers.Attributes
{
    public class OneTwoManyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public OneTwoManyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
