using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.Interfaces
{
  public  interface IAllOrders
    {
        IEnumerable<Order> Order { get; }
        IEnumerable<OrderDetail>  orderDetails { get; }
        void createOrder(Order order);
        void removeOrder(Order order,List<OrderDetail> orderDetails);
    }
}
