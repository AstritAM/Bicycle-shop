using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class BicycleRepository : IAllBicucle
    {
        private readonly AppDBContent appDB;
        public BicycleRepository (AppDBContent appDB)
        {
            this.appDB = appDB;
        }
        public IEnumerable<Bicycle> Bicycles => appDB.Bicycles.Include(c=>c.Category);

        public IEnumerable<Bicycle> getBicycles => appDB.Bicycles.Where(p=>p.isFavorit).Include(c=>c.Category) ;

        public void createBicycle(Bicycle bicycle)
        {
            appDB.Bicycles.Add(bicycle);
            appDB.SaveChanges();
           
        }
        public void RemoveBicycle(Bicycle bicycle)
        {
           
                        appDB.Bicycles.Remove(bicycle);
          

                appDB.SaveChanges();
            

        }

        public Bicycle getObjBicycle(int bicId) => appDB.Bicycles.FirstOrDefault(p => p.id == bicId);

    }
}
