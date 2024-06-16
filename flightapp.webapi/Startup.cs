using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using flightapp.business.Abstract;
using flightapp.business.Concrete;
using flightapp.data.Abstract;
using flightapp.data.Concrete.EfCore;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace flightapp.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        readonly string MyAllowOrigins = "_myAllowOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FlightContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddScoped<IFlightService,FlightManager>(); 
            services.AddScoped<ICategoryService,CategoryManager>(); 
            services.AddScoped<ICartService,CartManager>(); 
            services.AddScoped<IBookService,BookManager>(); 
          
            services.AddControllers();

            services.AddCors(options => {
                options.AddPolicy(
                    name: MyAllowOrigins,
                    builder => {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });


            // app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors(MyAllowOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
