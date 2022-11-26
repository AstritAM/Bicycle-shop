using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Model
{
    public class Category
    {
        public int id { get; set; }
        public string categName { get; set; }
        public string desc { get; set; }

        public string img { get; set; }

       public List<Bicycle> bicycles { get; set; }
    }
}
