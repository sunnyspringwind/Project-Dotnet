using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.UserDtos
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;
    }
}