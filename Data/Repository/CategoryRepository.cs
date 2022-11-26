using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;
using WebApplication2.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class CategoryRepository : IBicycleCategory
    {

        private readonly AppDBContent appDB;
        public CategoryRepository(AppDBContent appDB)
        {
            this.appDB = appDB;
        }
        public IEnumerable<Category> AllCategories => appDB.GetCategories;
    }
}
