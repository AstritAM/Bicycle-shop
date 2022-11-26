using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrderRepository(AppDBContent appDBContent,ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;  
        }

        public IEnumerable<Order> Order => appDBContent.Order;

        public IEnumerable<OrderDetail> orderDetails => appDBContent.OrderDetail;

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.shopCartItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    bicycleId=el.bicycle.id,
                    orderId=order.id,
                    price=el.bicycle.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
                
            }
            appDBContent.SaveChanges();
        }

        public void removeOrder(Order order,List<OrderDetail> orderDetails)
        {
            appDBContent.Order.Remove(order);
        foreach(var a in orderDetails)
            {
                appDBContent.OrderDetail.Remove(a);

            }
            appDBContent.SaveChanges();
        }
    }
}
