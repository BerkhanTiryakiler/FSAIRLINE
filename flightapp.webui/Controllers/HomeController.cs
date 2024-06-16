using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using flightapp.business.Abstract;
using flightapp.data.Abstract;
using flightapp.entity;
using flightapp.webui.Models;

namespace flightapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController:Controller
    {      
        private IFlightService _flightService;
        public HomeController(IFlightService flightService)
        {
            this._flightService=flightService;
        }
        
        public IActionResult Index()
        {
            var flightViewModel = new flightListViewModel()
            {
                Flights = _flightService.GetHomePageFlights()
            };

            return View(flightViewModel);
        }

        public async Task<IActionResult> GetflightsFromRestApi()
        {
            var flights = new List<Flight>();

            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:4200/api/flights"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flights = JsonConvert.DeserializeObject<List<Flight>>(apiResponse);
                }
            }
            return View(flights);
        }
      
        public IActionResult About()
        {
            return View();
        }

         public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}