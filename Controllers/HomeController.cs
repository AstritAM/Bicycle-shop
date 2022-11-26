using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllBicucle allBicucle;


        public HomeController(IAllBicucle _allBicucle)
        {
            allBicucle = _allBicucle;

        }
        public ViewResult Index()
        {
            var homeBicycle = new HomeViewModel
            {
                favBicycles = allBicucle.getBicycles
            };

            return View(homeBicycle);
        }
    }
}
