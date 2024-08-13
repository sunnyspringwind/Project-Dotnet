using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.Models
{
    public class HotelBooking
    {
        public int Id { get; set; }


        public int HotelId  { get; set; }

        public Hotel? Hotel { get; set; }    //navigation property

        public int UserId { get; set; }

        public User? User { get; set; }

        public DateTime BookingDate { get; set; }

        public int Duration { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public decimal TotalPrice { get; set; }

    }
}