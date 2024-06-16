using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using flightapp.data.Concrete.EfCore;
using flightapp.webui.Identity;

namespace flightapp.webui.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                        throw;
                    }
                }

                using (var bookingContext = scope.ServiceProvider.GetRequiredService<FlightContext>())
                {
                    try
                    {
                        bookingContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                        throw;
                    }
                }
            }
       
            return host;
        }
    }
}