using Data.Interface;
using Data.Model;
using googleShop.ViewModes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace googleShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICourse _corRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(ICourse repository, ShopCart shopCart)
        {
            _corRep = repository;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.getShopCartItems();
            _shopCart.listShopItem = items;

            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) {
            var item = _corRep.Courses.FirstOrDefault(i => i.Id == id);
            if (item != null) {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
