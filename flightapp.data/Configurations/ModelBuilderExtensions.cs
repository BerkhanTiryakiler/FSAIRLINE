using Microsoft.EntityFrameworkCore;
using flightapp.entity;

namespace flightapp.data.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder) 
        {
            builder.Entity<Flight>().HasData(
                new Flight(){FlightId=1,Name="London-Tokyo",Url= "london-tokyo", Price=2000,ImageUrl="1.jpg",Description="iyi telefon", IsApproved=true},
                new Flight(){FlightId=2,Name="Istanbul-Paris",Url= "istanbul-paris", Price=3000,ImageUrl="2.jpg",Description="9.30", IsApproved=false}
            );

            builder.Entity<Category>().HasData(
                new Category(){CategoryId=1,Name="Domestic Departures",Url="domestic"},
                new Category(){CategoryId=2,Name="International Departures",Url="international"}
              
            );

            builder.Entity<FlightCategory>().HasData(
                new FlightCategory(){FlightId=1,CategoryId=1},          
                new FlightCategory(){FlightId=1,CategoryId=2},          
                new FlightCategory(){FlightId=1,CategoryId=3},          
                new FlightCategory(){FlightId=2,CategoryId=1},          
                new FlightCategory(){FlightId=2,CategoryId=2},          
                new FlightCategory(){FlightId=2,CategoryId=3},          
                new FlightCategory(){FlightId=3,CategoryId=4},          
                new FlightCategory(){FlightId=4,CategoryId=3},          
                new FlightCategory(){FlightId=5,CategoryId=3},          
                new FlightCategory(){FlightId=5,CategoryId=1}       

           );
        }
    }
}