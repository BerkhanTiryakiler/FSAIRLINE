using System.Collections.Generic;
using flightapp.entity;

namespace flightapp.data.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetBooks(string userId);
    }
}