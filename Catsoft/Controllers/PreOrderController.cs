using System.Linq;
using System.Threading.Tasks;
using App.cms;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.Models;
using App.ViewModels.PreOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class PreOrderController : CommonController
    {
        private readonly CmsOptions _cmsOptions;
        private readonly TextResourceRepository _textResourceRepository;

        public PreOrderController(CatsoftContext catsoftContext, TextResourceRepository textResourceRepository,
            CmsOptions cmsOptions)
        {
            _textResourceRepository = textResourceRepository;
            _cmsOptions = cmsOptions;
            CatsoftContext = catsoftContext;
        }


        public IActionResult Index()
        {
            var home = new PreOrderPageViewModel
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.PreOrderPageModels.FirstOrDefault()
            };

            home.HeaderViewModel.CurrentPage = Menu.PreOrder;

            return View(home);
        }

        [HttpPost]
        public async Task<IActionResult> MakePreOrder(PreOrderDto preOrderDto)
        {
            var orderModel = new PreOrderModel
            {
                Comment = preOrderDto.Comment,
                Name = preOrderDto.Name,
                EmailOrPhone = preOrderDto.EmailOrPhone
            };

            await CatsoftContext.OrderModels.AddAsync(orderModel);
            await CatsoftContext.SaveChangesAsync();

            var contactsModel =
                await CatsoftContext.ContactsModels.FirstOrDefaultAsync(w => w.ContactType == ContactType.Email);

            var contactsInfoText = await _textResourceRepository.GetByTag(HttpContext, "Contact information");
            var nameText = await _textResourceRepository.GetByTag(HttpContext, "Name");
            var commentText = await _textResourceRepository.GetByTag(HttpContext, "Comment");
            var newOrderText = await _textResourceRepository.GetByTag(HttpContext, "New order");

            var text = $"{contactsInfoText} : {orderModel.EmailOrPhone}\n" +
                       $"{nameText} : {orderModel.Name}\n" +
                       $"\n{commentText} : {orderModel.Comment}";

            EmailService.Send(new EmailModel
            {
                From = contactsModel.Link,
                To = contactsModel.Link,
                Subject = newOrderText,
                Body = text
            }, _cmsOptions);

            return RedirectToAction("Index", "Home");
        }
    }
}