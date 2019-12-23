using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Data.Interface;
using Data.Mock;
using Microsoft.Extensions.Configuration;
using Data;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using Data.Model;

namespace googleShop
{
    public class Startup
    {

        private IConfigurationRoot _confSting;

        public Startup(IHostingEnvironment host, IHostingEnvironment env) {
            _confSting = new ConfigurationBuilder().SetBasePath(host.ContentRootPath).AddJsonFile("dbsettings.json")
           .AddJsonFile($"jsconfig.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables().Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<AppDBContent>(option => option.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.Configure<AppIdentitySettings>(_confSting.GetSection("AppIdentitySettings"));
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IAvatarFile, AvatarFileRepository>();
            services.AddTransient<IFileModel, FileModelRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor > ();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "{Courses}/{action}/{category?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            } 

        }
    }
}
