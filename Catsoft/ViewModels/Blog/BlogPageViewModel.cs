using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Blog
{
    public class BlogPageViewModel : CommonPageViewModel<BlogPageModel>
    {
        public List<ArticleModel> ArticleModels { get; set; }
    }
}
