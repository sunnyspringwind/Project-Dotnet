using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;
using wandermate_backend.DTOs.HotelDtos;
using wandermate_backend.Models;

namespace wandermate_backend.Controllers    //handles client interactions whereas dbcontext manages data
{
    [Route("wandermate_backend/hotel")]
    [ApiController]     // the above route runs the class below
    public class HotelController : ControllerBase   //everything about controlling routes .netCore.Mvc
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context) { //dependency injection
            _context = context; // store
        }

        [HttpGet]       // attribue and processes in routes

        public async Task<IActionResult> GetAll() {
            var hotels = await _context.Hotels.ToListAsync();  //inject or called from appdbcontext get all hotels as list
          
            var hotelsDto = hotels.Select(hotel => new HotelDto{ //instead of returning the data we get from database directly we used hotelDto to refine and get only required by GetDto
                Id = hotel.Id,
                Name = hotel.Name,
                Price = hotel.Price,
                Description = hotel.Description,
                Rating = hotel.Rating,
                FreeCancellation = hotel.FreeCancellation,
                ReserveNow = hotel.ReserveNow,
            }).ToList();
            return Ok(hotelsDto);
        }


        /* [HttpGet("{id}")] attribute configures the route for the action method. In this case, it indicates that the method should handle GET requests where the URL includes an id parameter.

        Parameter Binding: The {id} placeholder in the route is matched to a method parameter. ASP.NET Core automatically extracts the value from the URL and passes it to the method.*/

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            ;
                var hotel =await _context.Hotels.Where(h => h.Id == id).Select(h => new HotelDto {
                Id = h.Id,
                Name = h.Name,
                Price = h.Price,
                Description = h.Description,
                Rating = h.Rating,
                FreeCancellation = h.FreeCancellation,
                ReserveNow = h.ReserveNow,
            }).FirstOrDefaultAsync();       //first or default

            if (hotel == null)
                return NotFound();
            return Ok(hotel);
            
    }

        [HttpPost]

        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto hotelDto) {    // post data comes from body or form as your choice
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (hotelDto == null)
            {
                return NotFound();
            }

            var hotel = new Hotel {
                Name = hotelDto.Name,
                Price = hotelDto.Price,
                Description = hotelDto.Description,
                Rating = hotelDto.Rating,
                FreeCancellation = hotelDto.FreeCancellation,
                ReserveNow = hotelDto.ReserveNow,
            };
         

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            var hotelResponse = new HotelResponseDto
            {
                Name = hotelDto.Name,
                Price = hotelDto.Price,
                Description = hotelDto.Description,
                Rating = hotelDto.Rating,
                FreeCancellation = hotelDto.FreeCancellation,
                ReserveNow = hotelDto.ReserveNow,
            };
            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotelResponse);  //uses url of getbyid 
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditHotel([FromRoute] int id, [FromBody] HotelUpdateDto updatedData) {        //comes from model data of body and id 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbData = await _context.Hotels.FindAsync(id);    // find in db
            if (dbData == null) {
                return NotFound();
            }
            dbData.Name = updatedData.Name;
            dbData.Price = updatedData.Price;
            dbData.Image = updatedData.Image;
            dbData.Description = updatedData.Description;
            dbData.ReserveNow = updatedData.ReserveNow;
            dbData.FreeCancellation = updatedData.FreeCancellation;
            dbData.Rating = updatedData.Rating;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteHotel([FromRoute] int id) {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) {
                return NotFound();
            }
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync(); 
            return NoContent();
        }
    }
}