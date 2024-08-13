// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using wandermate_backend.Data;
// using wandermate_backend.DTOs.AccountDtos;

// namespace wandermate_backend.Controllers
// {
//     [Route("wandermate_backend/login")]
//     [ApiController]
//     public class LoginController : ControllerBase
//     {
//         private readonly ApplicationDbContext _dbContext;

//         public LoginController(ApplicationDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         [HttpPost]

//         public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
//         {
//             var registered = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == loginDto.Username);
//             if (registered == null)
//             {
//                 return NotFound("User Not found!");
//             }
//             bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, registered.Password);
//             if (!isPasswordValid)
//             {
//                 return BadRequest("Access Denied!");

//             }
//             return Ok("Welcome Pilot!");
//         }
//     }
// }