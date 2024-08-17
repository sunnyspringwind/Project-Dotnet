using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.CurrentUserDtos
{
    public class CurrentUserBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public string BookedFor { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public DateTime Checkin {get; set;}
        public DateTime Checkout { get; set; }
        public int TotalPrice { get; set; }

    }
}