using System;
using System.Collections.Generic;
using System.Text;
using GardenBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GardenBuddy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<GardenBed> GardenBeds { get; set; }

        public DbSet<PlantGarden> PlantGardens { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
           
        }
    }
}
