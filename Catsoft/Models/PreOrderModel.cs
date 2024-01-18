using System;
using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    [Access]
    public class PreOrderModel : Entity<PreOrderModel>
    {
        public string Name { get; set; }
        
        public string EmailOrPhone { get; set; }
        
        public string Comment { get; set; }
    }
}