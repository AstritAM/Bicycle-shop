using WebApplication2.Data.Model;
using WebApplication2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Mocks
{
    public class MockCategorycs : IBicycleCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>  {
                    new Category
                    {
                        categName = " Горные",
                        desc = "Горный велосипед подходит всем, кто любит активный отдых и поездки за городом. Если вы хотите купить модель," +
                        " подходящую возрасту, физическим особенностям, специфике эксплуатации, стоит выбрать из предложений магазина." +
                        " Горные велосипеды сложно спутать с другими видами. Они универсальны и пользуются повышенной популярностью. " +
                        "Они комфортны для езды по пересечённой местности и ровным велодорожкам городских улиц.",

                        img = "https://pro-veliki.ru/wp-content/uploads/2016/07/Totem-Inspiron-27.5-2016.jpg"
                    },
                     new Category
                    {
                        categName = " Горные",
                        desc = "Горный велосипед подходит всем, кто любит активный отдых и поездки за городом. Если вы хотите купить модель," +
                        " подходящую возрасту, физическим особенностям, специфике эксплуатации, стоит выбрать из предложений магазина." +
                        " Горные велосипеды сложно спутать с другими видами. Они универсальны и пользуются повышенной популярностью. " +
                        "Они комфортны для езды по пересечённой местности и ровным велодорожкам городских улиц.",

                        img = "https://pro-veliki.ru/wp-content/uploads/2016/07/Totem-Inspiron-27.5-2016.jpg"
                    }
                };
            }
        } 
    }
}
