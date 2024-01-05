﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class ProjectsPageModel : BasePage<ProjectsPageModel>
    {
        [DisplayName("Что-нибудь о услугах")]
        [DataType(DataType.Html)]
        [Show(false)]
        public string ServicesText { get; set; }
    }
}