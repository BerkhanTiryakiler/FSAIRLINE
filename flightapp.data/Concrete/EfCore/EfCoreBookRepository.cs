using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.data.Concrete.EfCore
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book>, IBookRepository
    {

        public EfCoreBookRepository(FlightContext context): base(context)
        {
            
        }
          
        private FlightContext bookingContext
        {
            get {return context as FlightContext; }
        }
        public List<Book> GetBooks(string userId)
        {

                var books = bookingContext.Books
                                    .Include(i=>i.BookItems)
                                    .ThenInclude(i=>i.Flight)
                                    .AsQueryable();

                if(!string.IsNullOrEmpty(userId))
                {
                    books = books.Where(i=>i.UserId ==userId);
                }

                return books.ToList();
        }
    }
}