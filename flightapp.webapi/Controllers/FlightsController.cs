using System;
using Microsoft.AspNetCore.Mvc;
using flightapp.business.Abstract;
using System.Threading.Tasks;
using flightapp.entity;
using System.Collections.Generic;
using flightapp.webapi.DTO;

namespace flightapp.webapi.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController: ControllerBase
    {
        private IFlightService _flightService;
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _flightService.GetAll();  

            var flightsDTO = new List<FlightDTO>();

            foreach (var p in flights)
            {
                flightsDTO.Add(FlightToDTO(p));
            }

            return Ok(flightsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var p = await _flightService.GetById(id);
            if(p==null)
            {
                return NotFound(); // 404
            }
            return Ok(FlightToDTO(p)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Flight entity)
        {
            await _flightService.CreateAsync(entity);
            return CreatedAtAction(nameof(GetProduct), new {id=entity.FlightId},FlightToDTO(entity));
        }

        // localhost:5000/api/flights/2
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Flight entity)
        {
            if (id!=entity.FlightId)
            {
                return BadRequest();
            }

            var flight = await _flightService.GetById(id);

            if(flight==null)
            {
                return NotFound();
            }

            await _flightService.UpdateAsync(flight,entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _flightService.GetById(id);

            if(product==null)
            {
                return NotFound();
            }

            await _flightService.DeleteAsync(product);
            return NoContent();
        }

        private static FlightDTO FlightToDTO(Flight p)
        {
            return new FlightDTO{
                    FlightId = p.FlightId,
                    Name = p.Name,
                    Url = p.Url,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                };
        }
    }
}