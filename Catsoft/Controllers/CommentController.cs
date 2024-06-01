using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CommentController : CommonController
    {
        public CommentController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            base.DbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel comment)
        {
            var orderModel = new CommentModel
            {
                Text = comment.Text,
                Name = comment.Name,
                ArticleModelId = comment.ArticleId
            };

            await DbContext.CommentModels.AddAsync(orderModel);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("Get", "Blog", new { id = comment.ArticleId });
        }
    }
}