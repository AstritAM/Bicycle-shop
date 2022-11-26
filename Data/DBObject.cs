using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.Data
{
    public class DBObject
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.GetCategories.Any())
            {
                content.GetCategories.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Bicycles.Any())
            {
                content.AddRange(
                    new Bicycle
                    {
                        name = "Горный велосипед BRAVO Hit 26 D FW",
                        img = "https://rostov-na-donu.velo-shop.ru/upload/iblock/e2a/bdof1o23eplq0f458bay59tw0uuqif98.jpg",
                        price = 40000,
                        count = 10,
                        firm = "BRAVO",
                        isFavorit = true,
                        Category = Categories["Горные"]
                    }

                    );
            }
            content.SaveChanges();

        }

        public static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category
                    {
                        categName = "Горные",
                        desc = "Горный велосипед подходит всем, кто любит активный отдых и поездки за городом. Если вы хотите купить модель," +
                        " подходящую возрасту, физическим особенностям, специфике эксплуатации, стоит выбрать из предложений магазина." +
                        " Горные велосипеды сложно спутать с другими видами. Они универсальны и пользуются повышенной популярностью. " +
                        "Они комфортны для езды по пересечённой местности и ровным велодорожкам городских улиц.",

                        img = "https://pro-veliki.ru/wp-content/uploads/2016/07/Totem-Inspiron-27.5-2016.jpg"
                    },
                     new Category
                    {
                        categName = "  Городские",
                        desc = "Городские байки отличаются комфортом, практичностью, удобством при езде в привычной одежде и стильным дизайном." +
                        "Велосипеды для города специально разработаны для передвижения по асфальтированным улицам и тротуарам.",

                        img = "https://pro-veliki.ru/wp-content/uploads/2016/07/Totem-Inspiron-27.5-2016.jpg"
                    }
                    };
                    category = new Dictionary<string, Category>();
                    foreach(var el in list)
                    {
                        category.Add(el.categName, el);
                    }

                }
                return category;

            }
        }
       
    }
}
