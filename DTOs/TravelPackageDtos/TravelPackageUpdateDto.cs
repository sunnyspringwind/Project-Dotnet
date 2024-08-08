using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.DTOs.TravelPackageDtos
{
    public class TravelPackageUpdateDto
    {
        public required string Title { get; set; }

        public string Weather { get; set; } = string.Empty;

        public List<string> Image { get; set; } = [];

        public string Description { get; set; } = string.Empty;

    }
}