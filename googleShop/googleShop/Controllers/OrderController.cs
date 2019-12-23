using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Data.Model;
using googleShop.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace googleShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly ShopCart _shopCart;

        private readonly AppIdentitySettings _appIdentitySettings;
        public OrderController(IOrder order, ShopCart shopCart, IOptions<AppIdentitySettings> appIdentitySettingsAccessor)
        {
            this._order = order;
            this._shopCart = shopCart;
            _appIdentitySettings = appIdentitySettingsAccessor.Value;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.listShopItem = _shopCart.getShopCartItems();

            if (_shopCart.listShopItem.Count == 0)
                ModelState.AddModelError("", "Добавте товары!");

            if (ModelState.IsValid)
            {
                _order.CreateOrder(order);

                SendMessage(order);

                return RedirectToAction("Complete");
            }

            return View(order); 
        }

        public async void SendMessage(Order order)
        {
            EmailService emailService = new EmailService(_appIdentitySettings.UserEmail.Eamil, _appIdentitySettings.UserEmail.Password, _appIdentitySettings.SettingEmail.Host, _appIdentitySettings.SettingEmail.Port);
            await emailService.SendEmailAsync(order.Email, "Заказ ShopCourses", "Здраствуйте " + order.Name + "!\nВы заказали сегодня курсы " + order.OrderTime.ToString() + "\nЗаказ прийдет в течении 2 - 3 дней.\n Спасибо за покупку ^_^");
        }

        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан!";
            _shopCart.clienShopCartItems();
            return View();
        }
    }
}