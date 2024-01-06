using System.Threading.Tasks;
using App.CMS;
using App.CMS.StaticHelpers;
using App.Models;
using App.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using EmailModel = App.CMS.StaticHelpers.EmailModel;

namespace App.Controllers
{
    public class OrderController : CommonController
    {
        public OrderController(Context context)
        {
            Context = context;
        }
 
        [HttpPost]
        public async Task<IActionResult> MakeOrder(OrderViewModel orderViewModel, CmsOptions cmsOptions)
        {
            var orderModel = new OrderModel()
            {
                About = orderViewModel.About,
                Name = orderViewModel.Name,
                DesireDate = orderViewModel.DesireDate,
                EmailOrPhone = orderViewModel.EmailOrPhone
            };

            await Context.OrderModels.AddAsync(orderModel);
            await Context.SaveChangesAsync();

            var text = $"Контакная информация : {orderModel.EmailOrPhone}\n" +
                       $"Имя фамилия : {orderModel.Name}\n" +
                       $"Желаемая дата : {orderModel.DesireDate.ToShortDateString()}" +
                       $"\nЧто конкретно хочет : {orderModel.About}";
            
            EmailService.Send(new EmailModel()
            {
                From = "support@ph-popovich.com",
                To = "support@ph-popovich.com",
                Subject = "Новый заказ",
                Body = text
            }, cmsOptions);
            
            return RedirectToAction("Index", "Home");
        }
    }
}