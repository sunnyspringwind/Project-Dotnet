using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.UserDtos
{
    public class UpdateUserDto
    {
   
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}