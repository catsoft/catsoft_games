﻿using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class BlogPageModel : MetaBasePage<BlogPageModel>
    {
    }
}