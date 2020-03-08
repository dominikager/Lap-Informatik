using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class MyContext : ApplicationDbContext
    {
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<RacePoint> RacePoints { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Season> Seasons { get; set; }
    }
}