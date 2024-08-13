using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wandermate_backend.Models;

namespace wandermate_backend.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}