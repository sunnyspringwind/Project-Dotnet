using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.HotelReviewsDtos
{
    public class CreateHotelReviewDto
    {
        public int Rating { get; set; }

        public string ReviewText { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int? HotelId { get; set; }
    }
}