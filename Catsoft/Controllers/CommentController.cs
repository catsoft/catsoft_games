using System.Threading.Tasks;
using App.Models;
using App.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CommentController : CommonController
    {
        public CommentController(Context context)
        {
            Context = context;
        }
 
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel comment)
        {
            var orderModel = new CommentModel()
            {
                Text = comment.Text,
                Name = comment.Name,
                ArticleModelId = comment.ArticleId
            };

            await Context.CommentModels.AddAsync(orderModel);
            await Context.SaveChangesAsync();

            return RedirectToAction("Get", "Blog", new { id = comment.ArticleId });
        }
    }
}