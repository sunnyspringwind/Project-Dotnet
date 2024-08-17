using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.ForgetPassword
{
    public class ResetPassword
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}