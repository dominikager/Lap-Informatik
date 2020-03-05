using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediApp.Models
{
    // Extendig the Application Context
    // Here i at my Entitys to the context
    public class MyContext : ApplicationDbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}