using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.HotelBookingDtos
{
    public class HotelBookingDto
    {
       [Required]
        public int Id { get; set; }
       [Required]
        public string HotelName { get; set; } = string.Empty;
       [Required]
        public string UserName { get; set; } = string.Empty;
       [Required]
        public DateTime BookingDate { get; set; }
       [Required]
        public int Duration { get; set; }
       [Required]
        public DateTime Checkin { get; set; }
       [Required]
        public DateTime Checkout { get; set; }
       [Required]
        public decimal TotalPrice { get; set; }

    }
}