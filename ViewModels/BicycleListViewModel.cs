using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.ViewModels
{
    public class BicycleListViewModel
    {
        public IEnumerable<Bicycle> allBicycles { get; set; }
        public string currCategory { get; set; }
     
    }
}
