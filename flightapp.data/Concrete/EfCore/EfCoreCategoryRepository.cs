using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {

        public EfCoreCategoryRepository(FlightContext context): base(context)
        {
            
        }
          
        private FlightContext bookingContext
        {
            get {return context as FlightContext; }
        }
        public void DeleteFromCategory(int FlightId, int categoryId)
        {
                var cmd = "delete from Flightcategory where FlightId=@p0 and CategoryId=@p1";
                bookingContext.Database.ExecuteSqlRaw(cmd,FlightId,categoryId);
        }

        public Category GetByIdWithFlights(int categoryId)
        {
                return bookingContext.Categories
                            .Where(i=>i.CategoryId==categoryId)
                            .Include(i=>i.FlightCategories)
                            .ThenInclude(i=>i.Flight)
                            .FirstOrDefault();
        }


    }
}