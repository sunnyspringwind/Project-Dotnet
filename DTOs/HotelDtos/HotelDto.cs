using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.HotelDtos
{

    //Handles data transfer scenerio  not replacing models
    public class HotelDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public List<string> Image { get; set; } = new List<string>();

        public string Description { get; set; } = string.Empty;

        public decimal Rating { get; set; }

        public bool FreeCancellation { get; set; }

        public bool ReserveNow { get; set; }
    }
}