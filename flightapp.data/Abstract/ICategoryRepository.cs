using System.Collections.Generic;
using flightapp.entity;

namespace flightapp.data.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetByIdWithFlights(int categoryId);

        void DeleteFromCategory(int FlightId,int categoryId);
    }
}