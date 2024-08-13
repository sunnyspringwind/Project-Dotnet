using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;
using wandermate_backend.DTOs.UserDtos;
using wandermate_backend.Models;

namespace wandermate_backend.Controllers
{
    [Route("wandermate_backend/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public AccountController(UserManager<AppUser> userManager)
    {
    }       

    [HttpPost("login")]

    public async Task<ActionResult<NewUserDto>> Login(LoginDto loginDto)
    {

        return Ok("Welcome Pilot!");
    }

    [HttpPost("register")]

    public async Task<ActionResult<NewUserDto>> Register([FromBody] RegisterDto registerDto)
    {
        return Ok("Welcome Pilot!");
    }  
        
    [HttpPut("update")]

    public async Task<ActionResult<NewUserDto>> Update([FromBody] UpdateUserDto updateDto)
    {
        return Ok("Welcome Pilot!");
    }  
    }

}