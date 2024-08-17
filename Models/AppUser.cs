using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace wandermate_backend.Models
{
        public class AppUser : IdentityUser
        {
            public List<HotelBooking> HotelBookings {get; set;}= new List<HotelBooking>();
        }
    }
