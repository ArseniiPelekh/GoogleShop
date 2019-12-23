using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text;

namespace Data.Model
{
    public class ShopCart
    {

        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = service.GetService<AppDBContent>();
            string shopCourseId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCourseId);

            return new ShopCart(contex) { ShopCartId = shopCourseId };
        }


        public void AddToCart(Course course)
        {
            appDBContent.ShopCourseItems.Add(new ShopCartItem
            {
                ShopCartId = this.ShopCartId,
                Course = course,
                Price = course.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopCartItems()
        {
            return appDBContent.ShopCourseItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Course).ToList();
        }

        public void clienShopCartItems()
        {
            var courses = appDBContent.ShopCourseItems.Where(c => c.ShopCartId == ShopCartId);

            foreach (var course in courses)
            {
                appDBContent.ShopCourseItems.Remove(course);
            }

            appDBContent.SaveChanges();
        }

    }
}
