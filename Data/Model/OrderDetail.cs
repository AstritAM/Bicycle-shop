using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int  bicycleId { get; set; }
        public int price { get; set; }
        
        public virtual Bicycle bicycle { get; set; }
        public virtual Order order { get; set; }
     
    }
}
