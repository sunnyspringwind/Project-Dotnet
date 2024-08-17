using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.HotelBookingDtos
{
    public class CreateNewHotelBookingDto
    {

        [Required]
        public int HotelId { get; set; }

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