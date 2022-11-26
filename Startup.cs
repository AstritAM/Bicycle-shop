using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication2.Data.Mocks;
using WebApplication2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Repository;
using WebApplication2.Data.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2
{

    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup( Microsoft.Extensions.Hosting.IHostingEnvironment environment)
        {
            _config = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection"))); ;
            services.AddMvc(op => op.EnableEndpointRouting = false);
            services.AddTransient<IAllBicucle, BicycleRepository>();
            services.AddTransient<IBicycleCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = false;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDBContent>().AddDefaultTokenProviders();
          
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "bycicleAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => {
            //     routes.MapRoute(
            //       name: "default",
            //       template: "{controller=Home}/{action=Index}/{id?}");

            //   routes.MapRoute(name: "categoryFilter", template: "Bicycle/List/{category?}", defaults: new { Controller = "Bicycle", action = "List" });
            //    routes.MapRoute(name:"admin", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute( "categoryFilter",  "Bicycle/List/{category?}", defaults: new { Controller = "Bicycle", action = "List" });
            });
        
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();

                DBObject.Initial(content);

            }
        }
    }
}
