using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_first.EfStuff;
using web_first.EfStuff.Repositores;

namespace web_first
{
    public class Startup
    {
        public const string AuthName = "SmileCookie";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebFirst1;Integrated Security=True;";
            services.AddDbContext<WebContext>(x => x.UseSqlServer(connectString));

            services.AddAuthentication()
                .AddCookie(AuthName, config =>
                {
                    config.LoginPath = "/GalleryAuthentification/Autorization";
                    config.AccessDeniedPath = "/User/AccessDenied";
                    config.Cookie.Name = "GalleryG";
                });

            services.AddScoped<ImageRepository>(x => 
                new ImageRepository(x.GetService<WebContext>()));
            services.AddScoped<ImageCommentRepository>(x =>
                new ImageCommentRepository(x.GetService<WebContext>()));
            services.AddScoped<GalleryUserRepository>(x =>
                new GalleryUserRepository(x.GetService<WebContext>()));
           



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
