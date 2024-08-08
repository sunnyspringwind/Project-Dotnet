using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.TravelPackageDtos
{
    public class TravelPackageResponseDto
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }

        public string Weather { get; set; } = string.Empty;

        public List<string> Image { get; set; } = [];

        public string Description { get; set; } = string.Empty;
    }
}