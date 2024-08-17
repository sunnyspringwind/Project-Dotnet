using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using wandermate_backend.Data;
using wandermate_backend.DTOs.HotelBookingDtos;
using wandermate_backend.Models;
using wandermate_backend.Extensions;
using Microsoft.EntityFrameworkCore;

namespace wandermate_backend.Controllers
{
    [Authorize]
    [Route("wandermate_backend/userbookings")]
    [ApiController]
    public class UserBookingsController : ControllerBase 
    {
        //first create attributes for all required classes

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        // invoke them through constructor

        public UserBookingsController(ApplicationDbContext dbContext, UserManager<AppUser> userManager) // these parameters are implictly argumented through dependency injection.
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        //now create http methods for handling http requests and responses. USE YOUR BRAIN TOO

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var userId = User.GetUserId();    // this is an extension method that gets the user id from the token
            var bookings = await _dbContext.HotelBookings
            .Where(b => b.UserId == userId)   // this is a linq query that gets all the bookings of the current user
            .Include(b => b.Hotel)      // this is an eager loading that includes the hotel details of the booking
            .Include(b => b.User)    // this is an eager loading that includes the user details of the booking
            .ToListAsync();

            var bookingsDto = bookings.Select(b => new HotelBookingDto
            {
                Id = b.Id,
                HotelName = b.Hotel.Name,
                UserName = User.GetUsername(),
                BookingDate = b.BookingDate,
                Duration = b.Duration,
                Checkin = b.Checkin,
                Checkout = b.Checkout,
                TotalPrice = b.TotalPrice
            }).ToList();

            return Ok(bookingsDto);
        }

        // for getting a single booking
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking([FromRoute]int id)  
        {
            var userId = User.GetUserId();
            var booking = await _dbContext.HotelBookings
            .Where(b => b.UserId == userId && b.Id == id)
            .Include(b => b.Hotel)
            .Include(b => b.User)
            .FirstOrDefaultAsync(); 

            if (booking == null)
            {
                return NotFound();
            }

            var bookingDto = new HotelBookingDto
            {
                Id = booking.Id,
                HotelName = booking.Hotel.Name,
                UserName = User.GetUsername(),
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                TotalPrice = booking.TotalPrice
            };

            return Ok(bookingDto);
        }

       // for booking a hotel
        [HttpPost]
        public async Task<IActionResult> BookHotel([FromBody] CreateNewHotelBookingDto createNewBookingDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

           var user = User.GetUserId();

           var hotel = await _dbContext.Hotels.FindAsync(createNewBookingDto.HotelId);

            if (hotel == null)
            {
                return BadRequest("Invalid HotelId.");
            }

            var newBooking =  new HotelBooking {
                HotelId = hotel.Id,
                UserId = user,
                BookingDate = createNewBookingDto.BookingDate,
                Duration = createNewBookingDto.Duration,
                Checkin = createNewBookingDto.Checkin,
                Checkout = createNewBookingDto.Checkout,
                TotalPrice = createNewBookingDto.TotalPrice,
           };

            //add the newBooking to the bookings db
            await _dbContext.HotelBookings.AddAsync(newBooking);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooking), new { id = newBooking.Id }, newBooking);
        }

        // for updating a booking
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBooking([FromRoute] int id, [FromBody] UpdateHotelBookingDto updateHotelBookingDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = User.GetUserId();
            var booking = await _dbContext.HotelBookings
            .Where(b => b.UserId == user && b.Id == id)
            .FirstOrDefaultAsync();

            if (booking == null) {
                return NotFound();
            }

            booking.BookingDate = updateHotelBookingDto.BookingDate;
            booking.Duration = updateHotelBookingDto.Duration;
            booking.Checkin = updateHotelBookingDto.Checkin;
            booking.Checkout = updateHotelBookingDto.Checkout;
            booking.TotalPrice = updateHotelBookingDto.TotalPrice;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // for deleting a booking
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking( int id) {
            var user = User.GetUserId();
            var booking = await _dbContext.HotelBookings
            .Where(b => b.UserId == user && b.Id == id)
            .FirstOrDefaultAsync();

            if (booking == null) {
                return NotFound();
            }

            _dbContext.HotelBookings.Remove(booking);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        
    }
}
}