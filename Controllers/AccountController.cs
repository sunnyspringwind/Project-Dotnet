using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;
using wandermate_backend.DTOs.UserDtos;
using wandermate_backend.DTOs.ForgetPassword;
using wandermate_backend.Interface;
using wandermate_backend.Models;
using wandermate_backend.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.Data;


namespace wandermate_backend.Controllers
{
    [Route("wandermate_backend/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /*The UserManager<TUser> class provides comprehensive methods for managing user accounts, including user creation, password management, role and claim management, and handling two-factor authentication.*/
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet("getAll")]

        public async Task<ActionResult> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = users.Select(user => new NewUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                UserId = user.Id
            }).ToList();

            return Ok(userDtos);
        }

        [HttpPost("register")]

        public async Task<ActionResult<NewUserDto>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };
                var createdUser = await _userManager.CreateAsync(newUser, registerDto.Password);    // add the created user to db.

                if (createdUser.Succeeded)
                {
                    var addRole = await _userManager.AddToRoleAsync(newUser, "User");
                    if (addRole.Succeeded)

                        return Ok(
                            new NewUserDto
                            {
                                Username = newUser.UserName,
                                Email = newUser.Email,
                                // Token = _tokenService.CreateToken(newUser) // this if you want the registered user get logged in auto
                            }
                        );
                    else
                    {
                        return StatusCode(500, addRole.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

            if (user == null)
            {
                return NotFound("Username does not exist.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid username or password");

            return Ok(new NewUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                UserId = user.Id
            });

        }

        [HttpPut("userUpdate")]
        [Authorize]

        public async Task<ActionResult<NewUserDto>> Update([FromBody] UpdateUserDto updateDto)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("user not found");
            }

            user.UserName = updateDto.Username;
            user.Email = updateDto.Email;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Faild to update user");
            }
            return Ok("User details updated");

        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest("Invalid email address.");
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password has been reset.");
            }

            return BadRequest("Error resetting password.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest("Email address not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Construct the email body with just the token
            var emailBody = $"Please use the following token to reset your password: {token}";

            await _emailSender.SendEmailAsync(request.Email, "Reset your password", emailBody);

            return Ok("Password reset email sent.");
        }

        [Authorize]
        [HttpGet("verify-token")]

        public async Task<IActionResult> VerifyToken(){
            return Ok();
        }


    }

}

