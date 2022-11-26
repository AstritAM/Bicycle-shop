using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Data.Repository;
using WebApplication2.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllBicucle  _allBicucle;
        private readonly ShopCart  _shopCart;
        public ShopCartController(IAllBicucle allBicucle, ShopCart shopCart )

        {
            _allBicucle = allBicucle;
            _shopCart = shopCart;

        }

        public ViewResult Index()
        {
            var item = _shopCart.GetShopItems();
            _shopCart.shopCartItems = item;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }
        public RedirectToActionResult addToCaret(int id)
        {
            var item = _allBicucle.Bicycles.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
              //  item.count -= 1;
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult removeToCaret(int id,int idod)
        {
            var item = _allBicucle.Bicycles.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                //  item.count -= 1;
                _shopCart.RemoveFCart(item,idod);
            }
            return RedirectToAction("Index");
        }

    }
}
