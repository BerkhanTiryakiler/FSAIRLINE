using flightapp.entity;

namespace flightapp.data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
        Cart GetByUserId(string userId);
        void DeleteFromCart(int cartId, int FlightId);
        void ClearCart(int cartId);
    }
}