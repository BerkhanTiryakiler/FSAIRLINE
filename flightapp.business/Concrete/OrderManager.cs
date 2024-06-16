using System.Collections.Generic;
using flightapp.business.Abstract;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.business.Concrete
{
    public class BookManager : IBookService
    {
         private readonly IUnitOfWork _unitofwork;
        public BookManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Book entity)
        {
            _unitofwork.Books.Create(entity);
            _unitofwork.Save();
        }

        public List<Book> GetBooks(string userId)
        {
            return  _unitofwork.Books.GetBooks(userId);
        }
    }
}