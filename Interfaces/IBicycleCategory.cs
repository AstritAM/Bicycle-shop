using WebApplication2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
   public interface IBicycleCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
