using System.Linq;
using System.Threading.Tasks;
using App.cms;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.Models;
using App.ViewModels.PreOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailModel = App.cms.StaticHelpers.EmailModel;

namespace App.Controllers
{
    public class PreOrderController : CommonController
    {
        private readonly TextResourceRepository _textResourceRepository;

        public PreOrderController(CatsoftContext catsoftContext, TextResourceRepository textResourceRepository)
        {
            _textResourceRepository = textResourceRepository;
            CatsoftContext = catsoftContext;
        }


        public IActionResult Index()
        {
            var home = new PreOrderPageViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.PreOrderPageModels.FirstOrDefault(),
            };

            home.HeaderViewModel.CurrentPage = Menu.PreOrder;

            return View(home);
        }

        [HttpPost]
        public async Task<IActionResult> MakePreOrder(PreOrderDto preOrderDto, CmsOptions cmsOptions)
        {
            var orderModel = new PreOrderModel()
            {
                Comment = preOrderDto.Comment,
                Name = preOrderDto.Name,
                EmailOrPhone = preOrderDto.EmailOrPhone
            };

            await CatsoftContext.OrderModels.AddAsync(orderModel);
            await CatsoftContext.SaveChangesAsync();

            var contactsModel = await CatsoftContext.ContactsModels.FirstOrDefaultAsync(w => w.ContactType == ContactType.Email);

            var contactsInfoText = _textResourceRepository.GetByTag("Contact_information");
            var nameText = _textResourceRepository.GetByTag("Name");
            var commentText = _textResourceRepository.GetByTag("Comment");
            var newOrderText = _textResourceRepository.GetByTag("New order");

            var text = $"{contactsInfoText} : {orderModel.EmailOrPhone}\n" +
                       $"{nameText} : {orderModel.Name}\n" +
                       $"\n{commentText} : {orderModel.Comment}";
            
            EmailService.Send(new EmailModel()
            {
                From = contactsModel.Link,
                To = contactsModel.Link,
                Subject = newOrderText,
                Body = text
            }, cmsOptions);
            
            return RedirectToAction("Index", "Home");
        }
    }
}