using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Model
{
    public class ShopCart
    {
        public string ShopCartID { get; set; }
        public List<ShopCartItem> shopCartItems { get; set; }
        private readonly AppDBContent appDB;
        public ShopCart(AppDBContent appDB)
        {
            this.appDB = appDB;
        }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            ;
            session.SetString("CartId", shopCartID);
            return new ShopCart(context) { ShopCartID = shopCartID };
        }
       

        public void AddToCart(Bicycle  bicycle)
        {
            appDB.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartID = ShopCartID,
                bicycle = bicycle,
                price = bicycle.price
            });

            appDB.SaveChanges();
        }

        public void RemoveFCart(Bicycle bicycle,int id)
        {
            var r=appDB.ShopCartItems.Where(a=>a.id==id);
           
            foreach(var a in r )
            {
                if (bicycle.id == a.bicycle.id)
                    appDB.ShopCartItems.Remove(a);
            }
         
       
            appDB.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDB.ShopCartItems.Where(c => c.ShopCartID == ShopCartID).Include(t => t.bicycle).ToList();
        }

    }
}
