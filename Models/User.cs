// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Linq;
// using System.Threading.Tasks;

// namespace wandermate_backend.Models
// {
//     [Table("User")]
//     public class User
//     {
//         [Key]
//         public int Id { get; set; }

//         public string Username { get; set; } = string.Empty;

//         public string Email { get; set; } = string.Empty;

//         public string Password { get; set; } = string.Empty;

//         public List<HotelBooking> Bookings { get; set; } = new List<HotelBooking>(); //one user may have multiple bookings

//     }
// }