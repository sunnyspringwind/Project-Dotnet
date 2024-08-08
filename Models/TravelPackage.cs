using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using wandermate_backend.Models;

namespace wandermate_backend.models
{
    [Table("TravelPackage")]
    public class TravelPackage
    {
       [Key]
        public int Id { get; set; }

        public required string Title {get; set;}

        public string Weather {get; set;} = string.Empty;

        public List<string> Image {get; set;} = [];

        public string Description { get; set; } = string.Empty;

        public TravelPackageDetails? TravelPackageDetails { get; set; }

        public List<TravelPackageReview> TravelPackageReviews { get; set; } = new List<TravelPackageReview>();
    }
}