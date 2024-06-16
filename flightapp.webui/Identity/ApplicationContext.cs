using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace flightapp.webui.Identity
{
    public class ApplicationContext: IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
    }
}