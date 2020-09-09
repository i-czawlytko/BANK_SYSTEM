using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ASP_Bank.Auth;
using ASP_Bank.ContextFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ASP_Bank
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataContext.server_adress = configuration.GetSection("ConnectionStrings:ServerAdress").Value;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles();
            services.AddMvc();
            

            services.AddDbContext<AuthContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6; // минимальное количество знаков в пароле



                options.Lockout.MaxFailedAccessAttempts = 10; // количество попыток о блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // конфигурация Cookie с целью использования их для хранения авторизации
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(
                r =>
                {
                    r.MapRoute(
                        name:"default",
                        template:"{controller=Bank}/{action=Index}"
                        );
                }
                );
        }
    }
}
