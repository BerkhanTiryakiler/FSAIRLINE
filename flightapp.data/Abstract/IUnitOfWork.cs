using System;
using System.Threading.Tasks;

namespace flightapp.data.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
         ICartRepository Carts {get;}
         ICategoryRepository Categories {get;}
         IBookRepository Books {get;}
         IFlightRepository Flights {get;} 
         void Save();
         Task<int> SaveAsync();

    }
}