using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermate_backend.models;
using wandermate_backend.Models;

namespace wandermate_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base (dbContextOptions)
        {
            
        }

        public DbSet <Hotel> Hotels {get; set;}

        public DbSet <TravelPackage> TravelPackages {get; set;}

        public DbSet <HotelReview> HotelReviews { get; set; }

        public DbSet <TravelPackageReview> TravelPackageReviews { get; set; }    

        public DbSet <User> Users{ get; set; }
        
    }
}