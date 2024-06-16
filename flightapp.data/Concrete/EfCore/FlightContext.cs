using Microsoft.EntityFrameworkCore;
using flightapp.data.Configurations;
using flightapp.entity;

namespace flightapp.data.Concrete.EfCore
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookItem> BookItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FlightCategoryConfiguration());    

            modelBuilder.Seed();        
        }


    }
}