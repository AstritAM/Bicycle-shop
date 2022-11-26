using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.ViewModels;
using WebApplication2.Data.Model;

namespace WebApplication2.Controllers
{
    public class BicycleController : Controller
    {

        private readonly IAllBicucle allBicycle;
        private readonly IBicycleCategory  bicycleCategory;

        public BicycleController(IAllBicucle bicucle, IBicycleCategory  category)
        {
            allBicycle = bicucle;
            bicycleCategory = category;
        }

     [Route("Bicycle/List")]
        [Route("Bicycle/List/{category}")]
        public ViewResult List(string category)
        {
            string cat = category;
            IEnumerable<Bicycle> bicycles=null;
            string currCategory = "";
            if (string.IsNullOrEmpty(cat))
            {
                bicycles = allBicycle.Bicycles.OrderBy(i=>i.id);
            }
            else {
                if (string.Equals("mountain", cat, StringComparison.OrdinalIgnoreCase)) {
                    bicycles = allBicycle.Bicycles.Where(i => i.Category.categName.Equals("Горные")).OrderBy(i => i.id);
                    currCategory = "Горные";
                }
                else if(string.Equals("city", cat, StringComparison.OrdinalIgnoreCase)){
                    bicycles = allBicycle.Bicycles.Where(i => i.Category.categName.Equals("Городские")).OrderBy(i => i.id);
                    currCategory = "Городские";
                }
                else if (string.Equals("baby", cat, StringComparison.OrdinalIgnoreCase))
                {
                    bicycles = allBicycle.Bicycles.Where(i => i.Category.categName.Equals("Детские")).OrderBy(i => i.id);
                    currCategory = "Детские";
                }
                else if (string.Equals("folding", cat, StringComparison.OrdinalIgnoreCase))
                {
                    bicycles = allBicycle.Bicycles.Where(i => i.Category.categName.Equals("Складные")).OrderBy(i => i.id);
                    currCategory = "Складные";
                }
                else if (string.Equals("racing", cat, StringComparison.OrdinalIgnoreCase))
                {
                    bicycles = allBicycle.Bicycles.Where(i => i.Category.categName.Equals("Гоночные")).OrderBy(i => i.id);
                    currCategory = "Гоночные";
                }

            }
            var bicObj = new BicycleListViewModel
            {
                allBicycles = bicycles,
                currCategory = currCategory
            };


           // BicycleListViewModel listViewModels = new BicycleListViewModel();
            


            return View(bicObj);
        }
    }
    
}
