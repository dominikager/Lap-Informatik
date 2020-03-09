using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class MyContext : ApplicationDbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<RepairSparepart> RepairSpareparts { get; set; }
        public virtual DbSet<RepairType> RepairTypes { get; set; }
        public virtual DbSet<Sparepart> Spareparts { get; set; }
    }
}