namespace MediApp.Migrations
{
    using MediApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MediApp.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MediApp.Models.MyContext context)
        {
            context.Medicines.AddOrUpdate(
                p => p.Name, 
                new Medicine { Name = "Viagra"},
                new Medicine { Name = "Aspirin" },
                new Medicine { Name = "Magnesium" },
                new Medicine { Name = "Neocitran" },
                new Medicine { Name = "Viagra" }
            );

            context.SaveChanges();
        }
    }
}
