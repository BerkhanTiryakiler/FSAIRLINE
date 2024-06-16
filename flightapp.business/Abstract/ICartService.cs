using flightapp.entity;

namespace flightapp.business.Abstract
{
    public interface ICartService
    {
          void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId,int productId,int seatnumber);
        void DeleteFromCart(string userId, int productId);
        void ClearCart(int cartId);
    }
}