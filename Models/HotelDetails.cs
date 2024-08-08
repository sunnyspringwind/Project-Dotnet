using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.Models
{
    [Table("HotelDetails")]
    public class HotelDetails
    {
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; } // Foreign key property

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
    }
}