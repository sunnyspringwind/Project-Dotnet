using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate_backend.Models
{
    [Table("Hotel")]
    public class Hotel
    {
    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id {get; set;}

        public required string Name {get; set;}

        public decimal Price {get; set;}
        
        public List<string> Image {get; set;} = new List<string>();

        public string Description {get; set;} = string.Empty;

        public decimal Rating { get; set; }

        public bool FreeCancellation {get; set;}

        public bool ReserveNow { get; set; }

        public HotelDetails? HotelDetails {get; set;}        //links 1 to 1 relation

        public List<HotelReview> HotelReviews {get; set;} = new List<HotelReview>();      //links 1 to many relation

        public List<HotelBooking> Bookings { get; set; } = new List<HotelBooking>();

    }
}