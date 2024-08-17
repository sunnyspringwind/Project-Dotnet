using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.UserDtos
{
    public class UpdateUserDto
    {
   
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; }
    }
}