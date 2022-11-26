using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable< Order> order { get; set; }
        public IEnumerable<Bicycle>  bicycles { get; set; }

    }
}
