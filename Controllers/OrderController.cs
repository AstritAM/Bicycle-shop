using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers
{
    public class OrderController:Controller

    {
        private readonly IAllBicucle allBicucle;
        private readonly IAllOrders  allOrders;
        private readonly ShopCart shopCart;
        public OrderController (IAllOrders  allOrders, ShopCart shopCart, IAllBicucle allBicucle)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            this.allBicucle = allBicucle;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.shopCartItems = shopCart.GetShopItems();
            if (shopCart.shopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }
            if(ModelState.IsValid)
            {
                
                allOrders.createOrder(order);
              //  Dec(order);
                return RedirectToAction("Complete");
            }  
          
            return View(order);
        }
        public void Dec(Order order)
        {

            var item = order.orderDetails;
            var a = new List<Bicycle>();
            foreach (var ir in item)
            {
               a= allBicucle.Bicycles.Where(i => i.id == ir.bicycleId).ToList();
            }
            foreach(var i in a)
            {
                i.count --;
            }
        }
        public IActionResult Complete()
        {

            ViewBag.Message = "Заказ успешно обработан";
                return View();
        }

    }
}
