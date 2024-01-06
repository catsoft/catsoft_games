using System;

namespace App.CMS.Controllers.Attributes
{
    public class OneTwoManyAttribute(string propertyName) : Attribute
    {
        public string PropertyName { get; set; } = propertyName;
    }
}
