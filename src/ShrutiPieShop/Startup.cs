using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShrutiPieShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ShrutiPieShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;


        public Startup(IHostingEnvironment env)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //  name: "categoryfilter",
                //  template: "Pie/{action}/{category?}",
                //  defaults: new { Controller = "Pie", action = "List" });

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            });


            //DbInitializer.Seed(app);

        }
    }
}
