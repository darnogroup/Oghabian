using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Date.Context;
using Domin.Entities;
using Ioc;
using Microsoft.EntityFrameworkCore;
using Oghabian.Areas.Admin.Models;
using Oghabian.Helper;

namespace Oghabian
{
    public class Startup
    {
        //MainSite
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataBaseContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Food"));
            });
            services.AddSignalR();
            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<DataBaseContext>().AddRoles<IdentityRole>()
                .AddDefaultTokenProviders().AddErrorDescriber<CustomErrorMessage>();
            services.Configure<IdentityOptions>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequiredLength = 6;
                option.SignIn.RequireConfirmedEmail = true;
                option.SignIn.RequireConfirmedAccount = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.Lockout.MaxFailedAccessAttempts = 4;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                option.User.RequireUniqueEmail = true;
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequiredUniqueChars = 1;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            });
           
            services.ConfigureApplicationCookie(cooke =>
            {
                cooke.ExpireTimeSpan = TimeSpan.FromDays(30);
                cooke.LoginPath = "/SignIn";
                cooke.AccessDeniedPath = "/";
                cooke.SlidingExpiration = true;
            });
            Dependency(services);
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
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/404";
                    await next();
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<AdminHub>("/AdminHub");
            });
        }

        public void Dependency(IServiceCollection service)
        {
            Injection.Service(service);
        }
    }
   
}
