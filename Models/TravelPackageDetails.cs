using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using wandermate_backend.models;

namespace wandermate_backend.Models
{
    [Table("TravelPackageDetails")]
    public class TravelPackageDetails
    {
        [Key]
        public int Id { get; set; }

        public required string Title { get; set; }

        public string Weather { get; set; } = string.Empty;

        public List<string> Image { get; set; } = [];

        public string Description { get; set; } = string.Empty;

        public int TravelPackageId { get; set; } // Foreign key property

        [ForeignKey("TravelPackageId")]
        public TravelPackage? TravelPackage { get; set; }
    }
}
