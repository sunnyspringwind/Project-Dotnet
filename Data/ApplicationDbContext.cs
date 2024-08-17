using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.models;
using wandermate_backend.Models;

namespace wandermate_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>  //dbcontext plus the identity framework for identity framework classes.
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<TravelPackage> TravelPackages { get; set; }

        public DbSet<HotelReview> HotelReviews { get; set; }

        public DbSet<TravelPackageReview> TravelPackageReviews { get; set; }

        // public DbSet<User> Users { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }



        //configure bookings table as it has multiple foreign key relations make

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure many-to-many 
            builder.Entity<HotelBooking>()
                .HasOne(hb => hb.Hotel)
                .WithMany(h => h.Bookings)
                .HasForeignKey(hb => hb.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HotelBooking>()
                .HasOne(hb => hb.User)
                .WithMany(u => u.HotelBookings)
                .HasForeignKey(hb => hb.UserId)
                .OnDelete(DeleteBehavior.Cascade);

    

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name ="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole{
                    Name ="User",
                    NormalizedName="USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }

}