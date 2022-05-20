using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebStore.Repository;
using WebStore.Data;
using WebStore.Data.Repository;
using Microsoft.Extensions.Hosting;
using WebStore.Data.Models;

namespace WebStore
{
    public class Startup
    {
        private IConfigurationRoot ConfString;
        public Startup(IHostEnvironment HostEnv)
        {
            ConfString = new ConfigurationBuilder().SetBasePath(HostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(ConfString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IProductCategory, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => WebStoreCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {       
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Products/{action}/{category?}", defaults: new { Controller="Products", action="List"});
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
