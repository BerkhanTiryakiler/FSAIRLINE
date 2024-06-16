using System.Collections.Generic;
using System.Threading.Tasks;
using flightapp.entity;

namespace flightapp.business.Abstract
{
    public interface IFlightService:IValidator<Flight>
    {
        Task<Flight> GetById(int id);
        Flight GetByIdWithCategories(int id);
        Flight GetFlightDetails(string url);
        List<Flight> GetFlightsByCategory(string name,int page,int pageSize);
        int GetCountByCategory(string category);        
        List<Flight> GetHomePageFlights();
        List<Flight> GetSearchResult(string searchString);
        Task<List<Flight>> GetAll();
        bool Create(Flight entity);
        Task<Flight> CreateAsync(Flight entity);
        void Update(Flight entity);
        void Delete(Flight entity);        
        Task DeleteAsync(Flight entity);        
        Task UpdateAsync(Flight entityToUpdate,Flight entity);
        bool Update(Flight entity, int[] categoryIds);
    }
}