using System.Linq;
using Microsoft.EntityFrameworkCore;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(FlightContext context): base(context)
        {
            
        }

        private FlightContext bookingContext
        {
            get {return context as FlightContext; }
        }
        public void ClearCart(int cartId)
        {
               var cmd = @"delete from CartItems where CartId=@p0";
               bookingContext.Database.ExecuteSqlRaw(cmd,cartId);
        }

        public void DeleteFromCart(int cartId, int FlightId)
        {
               var cmd = @"delete from CartItems where CartId=@p0 and FlightId=@p1";
               bookingContext.Database.ExecuteSqlRaw(cmd,cartId,FlightId);
        }

        public Cart GetByUserId(string userId)
        {
                return bookingContext.Carts
                            .Include(i=>i.CartItems)
                            .ThenInclude(i=>i.Flight)
                            .FirstOrDefault(i=>i.UserId==userId);
        }

        public override void Update(Cart entity)
        {
               bookingContext.Carts.Update(entity);
        } 
    }
}