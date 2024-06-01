using System.Linq;
using System.Threading.Tasks;
using App.cms;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
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

        public PreOrderController(CatsoftContext dbContext, TextResourceRepository textResourceRepository,
            CmsOptions cmsOptions, ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            _textResourceRepository = textResourceRepository;
            _cmsOptions = cmsOptions;
            base.DbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            var home = new PreOrderPageViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.PreOrder),
                FooterViewModel = await GetFooterViewModel(),
                Page = await DbContext.PreOrderPageModels.FirstOrDefaultAsync()
            };

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

            await DbContext.OrderModels.AddAsync(orderModel);
            await DbContext.SaveChangesAsync();

            var contactsModel =
                await DbContext.ContactsModels.FirstOrDefaultAsync(w => w.ContactType == ContactType.Email);

            var contactsInfoText = await _textResourceRepository.GetByTagAsync("Contact information");
            var nameText = await _textResourceRepository.GetByTagAsync("Name");
            var commentText = await _textResourceRepository.GetByTagAsync("Comment");
            var newOrderText = await _textResourceRepository.GetByTagAsync("New order");

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