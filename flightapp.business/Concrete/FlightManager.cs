using System.Collections.Generic;
using System.Threading.Tasks;
using flightapp.business.Abstract;
using flightapp.data.Abstract;
using flightapp.data.Concrete.EfCore;
using flightapp.entity;

namespace flightapp.business.Concrete
{
    public class FlightManager : IFlightService
    {
        private readonly IUnitOfWork _unitofwork;
        public FlightManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public bool Create(Flight entity)
        {
            if(Validation(entity))
            {       
                _unitofwork.Flights.Create(entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public async Task<Flight> CreateAsync(Flight entity)
        {
            await _unitofwork.Flights.CreateAsync(entity);
            await _unitofwork.SaveAsync();
            return entity;
        }

        public void Delete(Flight entity)
        {
            // iş kuralları
            _unitofwork.Flights.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Flight>> GetAll()
        {            
            return await _unitofwork.Flights.GetAll();
        }

        public async Task<Flight> GetById(int id)
        {
            return await _unitofwork.Flights.GetById(id);
        }

        public Flight GetByIdWithCategories(int id)
        {
            return _unitofwork.Flights.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _unitofwork.Flights.GetCountByCategory(category);
        }

        public List<Flight> GetHomePageFlights()
        {
           return _unitofwork.Flights.GetHomePageFlights();
        }

        public Flight GetFlightDetails(string url)
        {
            return _unitofwork.Flights.GetFlightDetails(url);
        }

        public List<Flight> GetFlightsByCategory(string name,int page,int pageSize)
        {
            return _unitofwork.Flights.GetFlightsByCategory(name,page,pageSize);
        }

        public List<Flight> GetSearchResult(string searchString)
        {
           return _unitofwork.Flights.GetSearchResult(searchString);
        }

        public void Update(Flight entity)
        {            
            _unitofwork.Flights.Update(entity);
            _unitofwork.Save();
        }

        public bool Update(Flight entity, int[] categoryIds)
        {
            if(Validation(entity))
            {
                if(categoryIds.Length==0)
                {
                    ErrorMessage += "You have to choose one flight.";
                    return false;
                }
                 _unitofwork.Flights.Update(entity,categoryIds);
                 _unitofwork.Save();
                return true;
            }
            return false;          
        }

        public string ErrorMessage { get; set; }

        public bool Validation(Flight entity)
        {
            var isValid = true;

            if(string.IsNullOrEmpty(entity.Source))
            {
                ErrorMessage += "Have to type a flight name.\n";
                isValid=false;
            }

            if(entity.Price<0)
            {
                ErrorMessage += "Can't be negative price.\n";
                isValid=false;
            }

            return isValid;
        }

        public async Task UpdateAsync(Flight entityToUpdate, Flight entity)
        {
            entityToUpdate.Source = entity.Source;
            entityToUpdate.Price = entity.Price;
            entityToUpdate.Destination = entity.Destination;
            entityToUpdate.Boarding = entity.Boarding;
            entityToUpdate.ETA = entity.ETA;
            entityToUpdate.Airline = entity.Airline;


            await _unitofwork.SaveAsync();
        }

        public async Task DeleteAsync(Flight entity)
        {
            _unitofwork.Flights.Delete(entity);
            await _unitofwork.SaveAsync();
        }
    }
}