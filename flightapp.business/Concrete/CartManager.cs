using flightapp.business.Abstract;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly IUnitOfWork _unitofwork;
        public CartManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void AddToCart(string userId, int flightId, int seatnumber)
        {
            var cart = GetCartByUserId(userId);

            if(cart!=null)
            {
                // eklenmek isteyen ürün sepette varmı (güncelleme)
                // eklenmek isteyen ürün sepette var ve yeni kayıt oluştur. (kayıt ekleme)

                var index = cart.CartItems.FindIndex(i=>i.FlightId==flightId);                
                if(index<0)
                {
                    cart.CartItems.Add(new CartItem(){
                        FlightId = flightId,
                        SeatNumber = seatnumber,
                        CartId = cart.Id
                    });
                }
                else{
                    cart.CartItems[index].SeatNumber += seatnumber;
                }

                _unitofwork.Carts.Update(cart);
                _unitofwork.Save();

            }
        }

        public void ClearCart(int cartId)
        {
            _unitofwork.Carts.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if(cart!=null)
            {
                _unitofwork.Carts.DeleteFromCart(cart.Id,productId);
            }   
        }

        public Cart GetCartByUserId(string userId)
        {
            return _unitofwork.Carts.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            _unitofwork.Carts.Create(new Cart(){UserId = userId});
            _unitofwork.Save();
        }
    }
}