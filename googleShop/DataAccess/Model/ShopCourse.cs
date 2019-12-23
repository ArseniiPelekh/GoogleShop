using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Model
{
    public class ShopCourse
    {

        private readonly AppDBContent appDBContent;

        public ShopCourse(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }

        public string ShopCourseId { get; set; }

        public List<ShopCourseItem> listShopItem { get; set; }
        
        public static ShopCourse GetCourse(IServiceProvider service) {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = service.GetService<AppDBContent>();
            string shopCourseId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCourseId);

            return new ShopCourse(contex) { ShopCourseId = shopCourseId };
        }

        public void AddToCart(Course course, int amout) {
            appDBContent.ShopCourseItems.Add(new ShopCartItem
            {
                ShopCartId = this.ShopCourseId,
                Course = course,
                Price = course.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopCourseItems() {
            return appDBContent.ShopCourseItems.Where(c => c.ShopCartId == ShopCourseId).Include(s => s.Course).ToList();
        }
        
    }
}
