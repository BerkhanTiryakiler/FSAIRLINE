using System.Collections.Generic;
using flightapp.entity;

namespace flightapp.business.Abstract
{
    public interface IBookService
    {
        void Create(Book entity);
        List<Book> GetBooks(string userId);
    }
}