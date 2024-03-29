using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_first.EfStuff;
using web_first.EfStuff.DbModel;
using web_first.EfStuff.Repositores;
using web_first.Models;
using web_first.Services;

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

            services.AddAuthentication(AuthName)
                .AddCookie(AuthName, config =>
                {
                    config.LoginPath = "/Gallery/Autorization";
                    config.AccessDeniedPath = "/User/AccessDenied";
                    config.Cookie.Name = "GalleryG";
                });
            RegisterMaper(services);
            

            services.AddScoped<ImageRepository>(x => 
                new ImageRepository(x.GetService<WebContext>()));
            services.AddScoped<ImageCommentRepository>(x =>
                new ImageCommentRepository(x.GetService<WebContext>()));
            services.AddScoped<GalleryUserRepository>(x =>
                new GalleryUserRepository(x.GetService<WebContext>()));
            services.AddScoped<UserService>(x =>
                new UserService(
                    x.GetService<GalleryUserRepository>(),
                    x.GetService<IHttpContextAccessor>()));

            services.AddHttpContextAccessor();
            



            services.AddControllersWithViews();
        }

        private void RegisterMaper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<AddImageViewModel, Image>();
            provider.CreateMap<Image, ImageUrlViewModel>()
                .ForMember(nameof(ImageUrlViewModel.Comments),
                opt => opt
                    .MapFrom( x => x.Comments.Select(c => c.Text).ToList()));

            var mapperConfiguration = new MapperConfiguration(provider);

            var mapper = new Mapper(mapperConfiguration);

            services.AddSingleton<IMapper>(x => mapper);
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
