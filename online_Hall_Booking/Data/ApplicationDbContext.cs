using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace online_Hall_Booking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> users { get; set; }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<HallAppointment> HallAppointment { get; set; }
        public DbSet<HallPackages> packages { get; set; }
        public DbSet<HallFacilities> FAcilities { get; set; }
        public DbSet<hallOrder>  Orders { get; set; }
        public DbSet<HallTiming> timings { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<HallTransaction> transactions { get; set; }
    }
}
