using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowOrderController : Controller
    {
        IAllOrders allOrders;
        IAllBicucle allBicucle;
        public ShowOrderController(IAllOrders allOrders, IAllBicucle allBicucle)
        {
            this.allOrders = allOrders;
            this.allBicucle = allBicucle;
        }
        public ViewResult Index()
        {
            OrderViewModel orderViewModel = new OrderViewModel
            {
                order = allOrders.Order,
                bicycles = allBicucle.getBicycles
                
            };
        foreach(var a in orderViewModel.order)
            {
                a.orderDetails = allOrders.orderDetails.Where(k => k.orderId == a.id).ToList();
            }
            return View(orderViewModel);
        }
        public IActionResult RemoveOrder(int id)
        {
            var item = allOrders.Order.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                item.orderDetails = allOrders.orderDetails.Where(k => k.orderId == item.id).ToList();
                //  item.count -= 1;
                allOrders.removeOrder(item, item.orderDetails);
            }
            return RedirectToAction("Complete");
        }
        public IActionResult Complete()
        {

            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
