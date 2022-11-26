using WebApplication2.Data.Model;
using WebApplication2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Mocks
{
    public class MockBicycle : IAllBicucle
    {
        private readonly IBicycleCategory bicycleCategory = new MockCategorycs();
        public IEnumerable<Bicycle> Bicycles {

            get
            {
                return new List<Bicycle>
                {
                    new Bicycle{name="Горный велосипед BRAVO Hit 26 D FW",img="https://rostov-na-donu.velo-shop.ru/upload/iblock/e2a/bdof1o23eplq0f458bay59tw0uuqif98.jpg",
                    price=40000, count=10, firm="BRAVO",  isFavorit=true,Category= bicycleCategory.AllCategories.First()}
                };
            }
        }

        public IEnumerable<Bicycle> getBicycles => throw new NotImplementedException();

        public void createBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
        }

        public Bicycle getObjBicycle(int roomId)
        {
            throw new NotImplementedException();
        }

        public void RemoveBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
        }
    }
}
