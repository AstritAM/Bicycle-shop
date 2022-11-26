using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Model
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Bicycle bicycle { get; set; }
      //  public int quntiti { get; set; }
        public int price { get; set; }

        public string ShopCartID { get; set; }
    }
}

