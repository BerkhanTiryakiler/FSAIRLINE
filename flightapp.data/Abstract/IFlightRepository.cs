using System.Collections.Generic;
using flightapp.entity;

namespace flightapp.data.Abstract
{
    public interface IFlightRepository: IRepository<Flight>
    {
       Flight GetFlightDetails(string url);
       Flight GetByIdWithCategories(int id);
       List<Flight> GetFlightsByCategory(string name,int page,int pageSize);
       List<Flight> GetSearchResult(string searchString);
       List<Flight> GetHomePageFlights();
       int GetCountByCategory(string category);
       void Update(Flight entity, int[] categoryIds);
    }
}