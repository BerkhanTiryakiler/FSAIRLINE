using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using flightapp.entity;

namespace flightapp.data.Configurations
{
    public class FlightCategoryConfiguration : IEntityTypeConfiguration<FlightCategory>
    {
        public void Configure(EntityTypeBuilder<FlightCategory> builder)
        {
           builder.HasKey(c => new { c.CategoryId, c.FlightId });

  
        }
    }
}