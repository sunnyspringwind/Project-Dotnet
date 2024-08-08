using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;
using wandermate_backend.DTOs.HotelReviewsDtos;
using wandermate_backend.Models;

namespace wandermate_backend.Controllers
{
    [Route("wandermate_backend/hotelReviews")]
    [ApiController]
    public class HotelReviewController : ControllerBase

    {
        private readonly ApplicationDbContext _context;

        public HotelReviewController(ApplicationDbContext context) {
        _context = context; // store
        }

    [HttpGet]       // attribue and processes in routes

    public async Task<IActionResult> GetAll()
    {
        var hotelReviews = await _context.HotelReviews.ToListAsync();  //inject or called from appdbcontext get all hotels as list
        return Ok(hotelReviews);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var hotelReview = await _context.HotelReviews.FindAsync(id);

        if (hotelReview == null)
        {   
            return NotFound();
        }
        return Ok(hotelReview);
    }

    [HttpPost]

    public async Task<IActionResult> CreateHotelReview([FromBody] CreateHotelReviewDto newReviewDto)
    {    // post data comes from body or form as your choice
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newReviewDto == null)
            {
                return NotFound();
            }

            var newReview = new HotelReview {
                Rating = newReviewDto.Rating,
                ReviewText = newReviewDto.ReviewText,
                CreatedOn = newReviewDto.CreatedOn,
                HotelId = newReviewDto.HotelId
            };
         await   _context.HotelReviews.AddAsync(newReview);

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = newReview.ReviewId}, newReview);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> EditHotelReview([FromRoute] int id, [FromBody] CreateHotelReviewDto updatedReview)
    {        //comes from model data of body and id 
        var dbData = await _context.HotelReviews.FindAsync(id);    // find in db
        if (dbData == null)
        {
            return NotFound();
        }
        dbData.Rating = updatedReview.Rating;
        dbData.ReviewText = updatedReview.ReviewText;
        dbData.CreatedOn = updatedReview.CreatedOn;
        dbData.HotelId = updatedReview.HotelId;

      await  _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteHotelReview([FromRoute] int id)
        {
            var hotelReview = await _context.HotelReviews.FindAsync(id);
            if (hotelReview == null)
            {
                return NotFound();
            }
            _context.HotelReviews.Remove(hotelReview);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
        
    