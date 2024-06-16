using System.Linq;
using Microsoft.AspNetCore.Mvc;
using flightapp.business.Abstract;
using flightapp.entity;
using flightapp.webui.Models;

namespace flightapp.webui.Controllers
{
    public class BookingController:Controller
    {
        private IFlightService _flightService;
        public BookingController(IFlightService flightService)
        {
            this._flightService=flightService;
        }

        // localhost/flights/
        public IActionResult List(string category,int page=1)
        {
            const int pageSize=2;
            var flightViewModel = new flightListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _flightService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Flights = _flightService.GetFlightsByCategory(category,page,pageSize)
            };

            return View(flightViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url==null)
            {
                return NotFound();
            }
            Flight flight = _flightService.GetFlightDetails(url);

            if(flight==null)
            {
                return NotFound();
            }
            return View(new FlightDetailModel{
                Flight = flight,
                Categories = flight.FlightCategories.Select(i=>i.Category).ToList()
            });
        }

        public IActionResult Search(string q)
        {
            var flightViewModel = new flightListViewModel()
            {
                Flights = _flightService.GetSearchResult(q)
            };

            return View(flightViewModel);
        }
    }
}