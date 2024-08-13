// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using wandermate_backend.Data;
// using wandermate_backend.DTOs.AccountDtos;
// using wandermate_backend.Models;

// namespace wandermate_backend.Controllers
// {
//     [Route("wandermate_backend/signup")]
//     [ApiController]
//     public class SignUpController : ControllerBase
//     {
//         private readonly ApplicationDbContext _dbContext;

//         public SignUpController(ApplicationDbContext dbContext) 
//         {
//             _dbContext = dbContext;
//         }

//         [HttpGet]

//         public async Task<IActionResult> GetAllUsers() {

//             var users = await _dbContext.Users.ToListAsync();

//             if (users == null) {
//                 return NotFound();
//             }

//             var usersDto = users.Select(user =>
//                 new ViewUserDto {
//                     Id = user.Id,
//                     Username = user.Username,
//                     Email = user.Email,
//                 }
//             ).ToList();
//             return Ok(usersDto);
//         }

//         [HttpGet("{id}")]

//         public async Task<IActionResult> GetUserById([FromRoute] int id) {
//             var userDto = await _dbContext.Users.Where(u => u.Id == id).Select(u => new ViewUserDto {
//                 Id = u.Id,
//                 Username = u.Username,
//                 Email = u.Email,
//             }).FirstOrDefaultAsync();

//             if (userDto == null) {
//                 return NotFound("No registered user");
//             }

//             return Ok(userDto);
//         }

//         [HttpPost] 

//         public async Task<IActionResult> CreateUser( [FromBody] NewUserDto userDto) {

//             if (!ModelState.IsValid) {
//                 return BadRequest();
//             }

//             var existingUser = await _dbContext.Users.AnyAsync(u => u.Username == userDto.Username);
//             if (existingUser)       
//             {
//                 return BadRequest("Username already exists.");
//             }

//             var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);  //hashedPassword
//             var user = new User {
//                 Username = userDto.Username,
//                 Email = userDto.Email,
//                 Password = hashedPassword
//             };
//             try
//             {
//             await _dbContext.Users.AddAsync(user);
//             await _dbContext.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetUserById), new {id = user.Id}, user);
//             }
//                catch (Exception ex)
            
//             {
//                 return StatusCode(500, ex.Message);
//             }
//         }

//         [HttpPut("{id}")]

//         public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto updatedUserDto) {

//             if (!ModelState.IsValid){
//                 return BadRequest();
//             }

//             var dbData = await _dbContext.Users.FindAsync(id);
//             if (dbData == null){
//                 return NotFound();
//             }

//             dbData.Username = updatedUserDto.Username;
//             dbData.Email = updatedUserDto.Email;

//             var hashedPassword = BCrypt.Net.BCrypt.HashPassword(updatedUserDto.Password);
//             dbData.Password = hashedPassword;

//             await _dbContext.SaveChangesAsync();
//             return Ok("User Details Updated");
//         }

//         [HttpDelete("{id}")]

//         public async Task<IActionResult> DeleteUser([FromRoute] int id)
//         {
//             var user = await _dbContext.Users.FindAsync(id);
//             if (user == null)
//             {
//                 return NotFound();
//             }
//      try
//      {
//                 _dbContext.Users.Remove(user);
//                 await _dbContext.SaveChangesAsync();
//                 return NoContent();
//             }
//      catch (Exception ex)
//             {
//                 return StatusCode(500, ex.Message);

//             }
           
//         }
// }
// }