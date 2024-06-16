using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using flightapp.business.Abstract;
using flightapp.business.Concrete;
using flightapp.data.Abstract;
using flightapp.data.Concrete.EfCore;
using flightapp.webui.EmailServices;
using flightapp.webui.Identity;
using Microsoft.AspNetCore.Cors;

namespace flightapp.webui
{
    public class Startup
    {      
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationContext>(options=> options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            services.AddDbContext<FlightContext>(options=> options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options=> {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options=> {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".bookingApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
         
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddScoped<IFlightService,FlightManager>(); 
            services.AddScoped<ICategoryService,CategoryManager>(); 
            services.AddScoped<ICartService,CartManager>(); 
            services.AddScoped<IBookService,BookManager>(); 

            services.AddScoped<IEmailSender,SmtpEmailSender>(i=> 
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"])
                );

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration,UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICartService cartService)
        {
            app.UseStaticFiles(); // wwwroot

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {     

                  endpoints.MapControllerRoute(
                    name: "books", 
                    pattern: "books",
                    defaults: new {controller="Cart",action="GetBooks"}
                ); 
              

                  endpoints.MapControllerRoute(
                    name: "checkout", 
                    pattern: "checkout",
                    defaults: new {controller="Cart",action="Checkout"}
                ); 
              
                endpoints.MapControllerRoute(
                    name: "cart", 
                    pattern: "cart",
                    defaults: new {controller="Cart",action="Index"}
                ); 

                 endpoints.MapControllerRoute(
                    name: "adminuseredit", 
                    pattern: "admin/user/{id?}",
                    defaults: new {controller="Admin",action="UserEdit"}
                ); 

                 endpoints.MapControllerRoute(
                    name: "adminusers", 
                    pattern: "admin/user/list",
                    defaults: new {controller="Admin",action="UserList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminroles", 
                    pattern: "admin/role/list",
                    defaults: new {controller="Admin",action="RoleList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminrolecreate", 
                    pattern: "admin/role/create",
                    defaults: new {controller="Admin",action="RoleCreate"}
                );      


                endpoints.MapControllerRoute(
                    name: "adminroleedit", 
                    pattern: "admin/role/{id?}",
                    defaults: new {controller="Admin",action="RoleEdit"}
                );          

                endpoints.MapControllerRoute(
                    name: "adminflights", 
                    pattern: "admin/flights",
                    defaults: new {controller="Admin",action="flightList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminflightcreate", 
                    pattern: "admin/flights/create",
                    defaults: new {controller="Admin",action="flightCreate"}
                );

                endpoints.MapControllerRoute(
                    name: "adminflightedit", 
                    pattern: "admin/flights/{id?}",
                    defaults: new {controller="Admin",action="flightEdit"}
                );

                 endpoints.MapControllerRoute(
                    name: "admincategories", 
                    pattern: "admin/categories",
                    defaults: new {controller="Admin",action="CategoryList"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategorycreate", 
                    pattern: "admin/categories/create",
                    defaults: new {controller="Admin",action="CategoryCreate"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategoryedit", 
                    pattern: "admin/categories/{id?}",
                    defaults: new {controller="Admin",action="CategoryEdit"}
                );
               

                // localhost/search    
                endpoints.MapControllerRoute(
                    name: "search", 
                    pattern: "search",
                    defaults: new {controller="booking",action="search"}
                );

                endpoints.MapControllerRoute(
                    name: "flighttdetails", 
                    pattern: "{url}",
                    defaults: new {controller="booking",action="details"}
                );

                endpoints.MapControllerRoute(
                    name: "flights", 
                    pattern: "flights/{category?}",
                    defaults: new {controller="booking",action="list"}
                );

                endpoints.MapControllerRoute(
                   name: "about",
                   pattern: "about",
                   defaults: new { controller = "home", action = "about" }
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
       
            SeedIdentity.Seed(userManager,roleManager,cartService,configuration).Wait();
        }
    }
}
