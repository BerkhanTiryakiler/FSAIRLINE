using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using flightapp.data.Abstract;
using flightapp.entity;

namespace flightapp.data.Concrete.EfCore
{
    public class EfCoreFlightRepository :
        EfCoreGenericRepository<Flight>, IFlightRepository
    {
        public EfCoreFlightRepository(FlightContext context): base(context)
        {
            
        }

        private FlightContext FlightContext
        {
            get {return context as FlightContext; }
        }
        public Flight GetByIdWithCategories(int id)
        {
            return FlightContext.Flights
                            .Where(i=>i.FlightId == id)
                            .Include(i=>i.FlightCategories)
                            .ThenInclude(i=>i.Category)
                            .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
          
            var flights = FlightContext.Flights.Where(i=>i.IsApproved).AsQueryable();

            if(!string.IsNullOrEmpty(category))
            {
                flights = flights
                                .Include(i=>i.FlightCategories)
                                .ThenInclude(i=>i.Category)
                                .Where(i=>i.FlightCategories.Any(a=>a.Category.Url == category));
            }

            return flights.Count();
           
        }
        public List<Flight> GetHomePageFlights()
        {
            return FlightContext.Flights
                .Where(i=>i.IsApproved && i.IsHome).ToList();
        }
        public Flight GetFlightDetails(string url)
        {
                return FlightContext.Flights
                                .Where(i=>i.Url==url)
                                .Include(i=>i.FlightCategories)
                                .ThenInclude(i=>i.Category)
                                .FirstOrDefault();

        }
        public List<Flight> GetFlightsByCategory(string name,int page,int pageSize)
        {
                var flights = FlightContext
                    .Flights
                    .Where(i=>i.IsApproved)
                    .AsQueryable();

                if(!string.IsNullOrEmpty(name))
                {
                    flights = flights
                                    .Include(i=>i.FlightCategories)
                                    .ThenInclude(i=>i.Category)
                                    .Where(i=>i.FlightCategories.Any(a=>a.Category.Url == name));
                }

                return flights.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }
        public List<Flight> GetSearchResult(string searchString)
        {
                var flights = FlightContext
                    .Flights
                    .Where(i=>i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                    .AsQueryable();

                return flights.ToList();
        }

        public void Update(Flight entity, int[] categoryIds)
        {
                var flight = FlightContext.Flights
                                    .Include(i=>i.FlightCategories)
                                    .FirstOrDefault(i=>i.FlightId==entity.FlightId);


                if(flight!=null)
                {
                    flight.Source = entity.Source;
                    flight.Destination = entity.Destination;
                    flight.Price = entity.Price;
                    flight.Url =entity.Url;
                    flight.Boarding = entity.Boarding;
                    flight.ETA = entity.ETA;
                    flight.Airline = entity.Airline;
                    flight.ImageUrl =entity.ImageUrl;
                    flight.IsApproved=entity.IsApproved;
                    flight.IsHome=entity.IsHome;

                    flight.FlightCategories = categoryIds.Select(catid=>new FlightCategory()
                    {
                        FlightId=entity.FlightId,
                        CategoryId = catid
                    }).ToList();

                }
        }
    }
}