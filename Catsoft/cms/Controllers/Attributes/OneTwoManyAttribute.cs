using System;

namespace App.cms.Controllers.Attributes
{
    public class OneTwoManyAttribute(string propertyName) : Attribute
    {
        public string PropertyName { get; set; } = propertyName;
    }
}