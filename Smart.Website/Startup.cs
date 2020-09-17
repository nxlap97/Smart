using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Data;
using Smart.Data.Infrastructor;
using Smart.Service.EF;
using Smart.Service.Interfaces;
using Smart.Website.Infrastructor.SignalR_Message;
using Smart.Website.Services;

namespace Smart.Website
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               o => o.MigrationsAssembly("Smart.Data")));

            //services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient(typeof(IReadOnlyRepository), typeof(ReadOnlyRepostory));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IAppRoleService, AppRoleService>();
           

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IViewEnginerService, ViewEnginerService>();

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            //
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(60);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});


            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //
            //    options.LoginPath = "/Customer/Login";
            //    options.AccessDeniedPath = "/Customer/Login";
            //    options.SlidingExpiration = true;
            //});


            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //        .AddCookie();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = new PathString("/dang-nhap.html");
                 options.ReturnUrlParameter = "RequestPath";
                 options.Events.OnRedirectToLogin = (context) =>
                 {
                     context.Response.StatusCode = 401;
                     return Task.CompletedTask;
                 };

             
             });

            ConfigureSignalR(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        public void ConfigAuthCustomer(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie("cookies", options =>
            {
                options.AccessDeniedPath = new PathString("/dang-nhap.html");
                // access
                options.Cookie = new CookieBuilder
                {
                    //Domain = "",
                    HttpOnly = true,
                    Name = ".aspNetCore.Security.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
                options.Events = new CookieAuthenticationEvents
                {
                    OnSignedIn = context =>
                    {
                        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                            "OnSignedIn", context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },
                    OnSigningOut = context =>
                    {
                        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                            "OnSigningOut", context.HttpContext.User.Identity.Name);
                        return Task.CompletedTask;
                    },
                    OnValidatePrincipal = context =>
                    {
                        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                            "OnValidatePrincipal", context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    }
                };
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = new PathString("/dang-nhap.html");
                options.ReturnUrlParameter = "RequestPath";
                options.SlidingExpiration = true;
            });
        }

        public void ConfigureSignalR(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins("http://localhost:3000")
                       .AllowCredentials();
               }));
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseCookiePolicy(new CookiePolicyOptions() {

                MinimumSameSitePolicy = SameSiteMode.Strict,
            });




            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseSignalR(routes =>
            {
                routes.MapHub<SmartHub>("/SmartHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
