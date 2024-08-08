using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;
using wandermate_backend.DTOs.TravelPackageDtos;
using wandermate_backend.models;

namespace wandermate_backend.Controllers
{
    [Route("wandermate_backend/travelPackages")]
    [ApiController]
    public class TravelPackageController : ControllerBase 
    {
        private readonly ApplicationDbContext _context;

        public TravelPackageController(ApplicationDbContext context) { 
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var travelPackages = await _context.TravelPackages.ToListAsync();  //inject or called from appdbcontext get all travelPackages as list

            var travelPackageDto = travelPackages.Select(travelPackage => new TravelPackageDto
            { //instead of returning the data we get from database directly we used travelPackageDto to refine and get only required by GetDto
                Id = travelPackage.Id,
                Title = travelPackage.Title,
               Weather = travelPackage.Weather,
               Image = travelPackage.Image,
               Description = travelPackage.Description
            }).ToList();
            return Ok(travelPackageDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var travelPackage = await _context.TravelPackages.Where(travelPkg => travelPkg.Id == id).Select(travelPkg => new TravelPackageDto
            {   
                Id = travelPkg.Id,
                Title = travelPkg.Title,
                Weather = travelPkg.Weather,
                Image = travelPkg.Image,
                Description = travelPkg.Description
            }).FirstOrDefaultAsync();       //first or default

            if (travelPackage == null)
                return NotFound();
            return Ok(travelPackage);

        }

        [HttpPost]

        public async Task<IActionResult> CreateTravelPackage([FromBody] CreateTravelPackageDto travelPackageDto)
        {    // post data comes from body or form as your choice
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (travelPackageDto == null)
            {
                return NotFound();
            }

            var travelPackage = new TravelPackage
            {
                Title = travelPackageDto.Title,
                Weather = travelPackageDto.Weather,
                Image = travelPackageDto.Image,
                Description = travelPackageDto.Description
            };
            

            await _context.TravelPackages.AddAsync(travelPackage);
            await _context.SaveChangesAsync();

            var responseDto = new TravelPackageResponseDto
            {
                Id = travelPackage.Id,
                Title = travelPackage.Title,
                Weather = travelPackage.Weather,
                Image = travelPackage.Image,
                Description = travelPackage.Description
            };
            return CreatedAtAction(nameof(GetById), new { id = travelPackage.Id }, responseDto);  //uses url of getbyid 
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditTravelPackage([FromRoute] int id, [FromBody] TravelPackageUpdateDto updatedData)
        {        //comes from model data of body and id 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbData = await _context.TravelPackages.FindAsync(id);    // find in db
            if (dbData == null)
            {
                return NotFound();
            }

            dbData.Title = updatedData.Title;
            dbData.Weather = updatedData.Weather;
            dbData.Image = updatedData.Image;
            dbData.Description = updatedData.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTravelPackage([FromRoute] int id)
        {
            var travelPackage =await _context.TravelPackages.FindAsync(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            _context.Remove(travelPackage);
           await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}