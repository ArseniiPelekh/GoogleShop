using Data.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrderRepository(AppDBContent appDB, ShopCart shopCart)
        {
            this.appDBContent = appDB;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Orders.Add(order);

            var items = shopCart.listShopItem;

            foreach (var el in items) {
                var orderDetail = new OrderDitail()
                {
                    CourseId = el.Course.Id,
                    OrderId = order.Id,
                    Price = el.Course.Price
                };
                appDBContent.OrderDitails.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
