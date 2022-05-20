using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly WebStoreCart webStoreCart;

        public OrdersRepository(AppDBContent appDBContent, WebStoreCart webStoreCart)
        {
            this.webStoreCart = webStoreCart;
            this.appDBContent = appDBContent;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = webStoreCart.listWebStoreItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    productId = el.product.id,
                    orderId = order.id,
                    price = el.product.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
