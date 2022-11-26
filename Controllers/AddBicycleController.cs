using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    [Area("Admin")]
    public class AddBicycleController : Controller
    {
        private readonly IBicycleCategory bicycleCategory;
        private readonly IAllBicucle allBicucle;

        public AddBicycleController(IBicycleCategory category, IAllBicucle allBicucle)
        {
            this.allBicucle = allBicucle;
            bicycleCategory = category;
        }
        public ActionResult Index()

        {
            IEnumerable<Bicycle> bicycles = allBicucle.Bicycles.OrderBy(i => i.categoryId);
            var bicObj = new BicycleListViewModel
            {
                allBicycles = bicycles
            };
        
            return View(bicObj);
        }

        public ActionResult Create()
        {
            Bicycle bicycleListViewModel = new Bicycle();
            bicycleListViewModel.listOfType = (from obj in bicycleCategory.AllCategories
                                               select new SelectListItem()
                                               {
                                                   Text = obj.categName,
                                                   Value = obj.id.ToString()
                                               }).ToList();
            return View(bicycleListViewModel);
        }
        [HttpPost]
          public ActionResult Create(Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                allBicucle.createBicycle(bicycle);
              
            }
            return RedirectToAction("Complete");
        }
        public RedirectToActionResult RemoveBicycle(int id)
        {
            var item = allBicucle.Bicycles.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                //  item.count -= 1;
               allBicucle.RemoveBicycle(item);
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
