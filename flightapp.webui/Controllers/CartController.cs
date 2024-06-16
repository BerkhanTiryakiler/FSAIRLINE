using System;
using System.Collections.Generic;
using System.Linq;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using flightapp.business.Abstract;
using flightapp.entity;
using flightapp.webui.Identity;
using flightapp.webui.Models;

namespace flightapp.webui.Controllers
{
    [Authorize]
    public class CartController:Controller
    {
        private ICartService _cartService;
        private IBookService _bookService;
        private UserManager<User> _userManager;
        public CartController(IBookService bookService,ICartService cartService,UserManager<User> userManager)
        {
            _cartService = cartService;
            _bookService = bookService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel(){
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=>new CartItemModel()
                {
                    CartItemId = i.Id,
                    flightId = i.FlightId,
                    Name = i.Flight.Name,
                    Price = (double)i.Flight.Price,
                    ImageUrl = i.Flight.ImageUrl,
                    SeatNumber =i.SeatNumber

                }).ToList()
            });
        } 

        [HttpPost]
        public IActionResult AddToCart(int flightId,int seatnumber)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId,flightId,seatnumber);
            return RedirectToAction("Index");
        } 

        [HttpPost]
        public IActionResult DeleteFromCart(int flightId)
        {
             var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId,flightId);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            
            var bookModel = new BookModel();

            bookModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=>new CartItemModel()
                {
                    CartItemId = i.Id,
                    flightId = i.FlightId,
                    Name = i.Flight.Name,
                    Price = (double)i.Flight.Price,
                    ImageUrl = i.Flight.ImageUrl,
                    SeatNumber =i.SeatNumber

                }).ToList()
            };
            
            return View(bookModel);
        }

        [HttpPost]
        public IActionResult Checkout(BookModel model)
        {
            if(ModelState.IsValid)
            {            
                var userId = _userManager.GetUserId(User);                
                var cart = _cartService.GetCartByUserId(userId);

                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i=>new CartItemModel()
                    {
                        CartItemId = i.Id,
                        flightId = i.FlightId,
                        Name = i.Flight.Name,
                        Price = (double)i.Flight.Price,
                        ImageUrl = i.Flight.ImageUrl,
                        SeatNumber =i.SeatNumber
                    }).ToList()
                };

                var payment = PaymentProcess(model);

                if(payment.Status=="success")
                {
                    SaveBook(model,payment,userId);
                    ClearCart(model.CartModel.CartId);
                    return View("Success");
                }else
                {
                    var msg = new AlertMessage()
                    {            
                        Message = $"{payment.ErrorMessage}",
                        AlertType = "danger"
                    };

                    TempData["message"] =  JsonConvert.SerializeObject(msg);
                    }
                }
            return View(model);
        }

        public IActionResult GetBooks()
        {
            var userId = _userManager.GetUserId(User);    
            var books =_bookService.GetBooks(userId);

            var bookListModel = new List<BookListModel>();
            BookListModel bookModel;
            foreach (var book in books)
            {
                bookModel = new BookListModel();

                bookModel.BookId = book.Id;
                bookModel.BookNumber = book.BookNumber;
                bookModel.BookDate = book.BookDate;
                bookModel.Phone = book.Phone;
                bookModel.FirstName = book.FirstName;
                bookModel.LastName = book.LastName;
                bookModel.Email = book.Email;
                bookModel.Address = book.Address;
                bookModel.City = book.City;
                bookModel.BookState = book.BookState;
                bookModel.PaymentType = book.PaymentType;

                bookModel.BookItems = book.BookItems.Select(i=>new BookItemModel(){
                        BookItemId = i.Id,
                        Name = i.Flight.Name,
                        Price = (double)i.Price,
                        SeatNumber = i.SeatNumber,
                        ImageUrl = i.Flight.ImageUrl
                }).ToList();

                bookListModel.Add(bookModel);
            }


            return View("Books", bookListModel);
        }

        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }

        private void SaveBook(BookModel model, Payment payment, string userId)
        {
           var book = new Book();

           book.BookNumber = new Random().Next(111111,999999).ToString();
           book.BookState = EnumBookState.completed;
           book.PaymentType = EnumPaymentType.CreditCard;
           book.PaymentId = payment.PaymentId;
           book.ConversationId = payment.ConversationId;
           book.BookDate = new DateTime();
           book.FirstName = model.FirstName;
           book.LastName = model.LastName;
           book.UserId = userId;
           book.Address = model.Address;
           book.Phone = model.Phone;
           book.Email = model.Email;
           book.City = model.City;
           book.Note = model.Note;

           book.BookItems = new List<entity.BookItem>();

            foreach (var item in model.CartModel.CartItems)
            {
                var bookItem = new flightapp.entity.BookItem()
                {
                    Price = item.Price,
                    SeatNumber = item.SeatNumber,
                    FlightId = item.flightId
                };
                book.BookItems.Add(bookItem);
            }
            _bookService.Create(book);
        }

        private Payment PaymentProcess(BookModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-RStpAR6sBz86RpFTuWPyF7hjh8c8g9E4";
            options.SecretKey = "sandbox-0zu0oxpXipwFsSGu1FrSofDVhTrWig2p";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
                    
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111,999999999).ToString();
            request.Price = model.CartModel.TotalPrice().ToString();
            request.PaidPrice = model.CartModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //  paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.flightId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Telefon";
                basketItem.Price = item.Price.ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }          
            request.BasketItems = basketItems;
            return Payment.Create(request, options);            
        }
   

   
    }
}