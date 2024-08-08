using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using wandermate_backend.models;

namespace wandermate_backend.Models
{
    public class TravelPackageReview
    {
        [Key]

        public int ReviewId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int? TravelPackageId { get; set; }

        public TravelPackage? TravelPackage { get; set; }
    }
}