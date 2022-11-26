using WebApplication2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
   public interface IAllBicucle
    {
        IEnumerable<Bicycle> Bicycles { get; }
        IEnumerable<Bicycle> getBicycles { get; }
        Bicycle getObjBicycle(int roomId) ;
        void createBicycle(Bicycle  bicycle);
        void RemoveBicycle(Bicycle bicycle);
    }
}
