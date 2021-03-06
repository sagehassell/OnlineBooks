using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OnlineBooks
{
    public class Startup
    {
        //constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //let us set up the MVC system
            services.AddControllersWithViews();

            //add a DB context services
            services.AddDbContext<BooksDBContext>(options =>
           {
               //set the connection string to the one I just made
               options.UseSqlite(Configuration["ConnectionStrings:BooksConnection"]);
           });
            
            //add scoped - so each person gets their own mini version of the DB
            services.AddScoped<IBooksRepository, EFBooksRepository>();

            //razor page
            services.AddRazorPages();

            //set up sessions
            services.AddDistributedMemoryCache();
            services.AddSession();

            //add cart
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //build endpoint for classification - the structre for how people access things on our site
                endpoints.MapControllerRoute("classpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "home", action = "index" }
                    );

                endpoints.MapControllerRoute("page",
                    "P{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //for razor pages
                endpoints.MapRazorPages();
            });

            //This will call the EnsurePopulated method in Seed Data and tell us if it has already been migrated
            SeedData.EnsurePopulated(app);
        }
    }
}
