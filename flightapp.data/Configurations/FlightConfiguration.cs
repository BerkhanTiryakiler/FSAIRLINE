using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using flightapp.entity;

namespace flightapp.data.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(m=>m.FlightId);

            builder.Property(m=>m.Source).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Destination).IsRequired().HasMaxLength(100);


            builder.Property(m=>m.DateAdded).HasDefaultValueSql("getdate()");  // mssql
            // builder.Property(m=>m.DateAdded).HasDefaultValueSql ("date('now')");   // sqlite            
        }
    }
}