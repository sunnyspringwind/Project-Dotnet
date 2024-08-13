using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.UserDtos
{
    public class NewUserDto
    {
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Token { get; set; }
        public string UserId { get; set; }
    }
}