using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bicycle> favBicycles { get; set; }
    }
}
