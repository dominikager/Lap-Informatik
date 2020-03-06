namespace SkiVerleih.Migrations
{
    using SkiVerleih.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SkiVerleih.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkiVerleih.Models.MyContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.FirstName,
                new Customer { FirstName = "Dominik", LastName = "Ager", Email = "info@ager-dominik.at", Phone = "+43660666666" },
                new Customer { FirstName = "Hansi", LastName = "Hinterseer", Email = "hansi@gmail.com", Phone = "+43660666666" },
                new Customer { FirstName = "Helene", LastName = "Fischer", Email = "fischer@gmail.com", Phone = "+43660666666" },
                new Customer { FirstName = "John", LastName = "Doe", Email = "doe@gmail.com", Phone = "+43660666666" }
            );

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                new Category { CategoryId = 1, Name = "Helm"},
                new Category { CategoryId = 2, Name = "Ski" },
                new Category { CategoryId = 3, Name = "Snowboard" },
                new Category { CategoryId = 4, Name = "Stecken" }
            );

            context.SaveChanges();

            context.Articles.AddOrUpdate(
                c => c.Name,
                new Article { Name = "Atomic Redster", Number = 1001, PricePerDay = 25, Stock = 4, CategoryId = 2 },
                new Article { Name = "Head Supershape", Number = 1002, PricePerDay = 2, Stock = 1, CategoryId = 2 },
                new Article { Name = "Atomic Punx", Number = 1003, PricePerDay = 15, Stock = 13, CategoryId = 2 },
                new Article { Name = "K2 Protect", Number = 3001, PricePerDay = 15, Stock = 13, CategoryId = 1 },
                new Article { Name = "Burton X", Number = 2001, PricePerDay = 5, Stock = 13, CategoryId = 3 },
                new Article { Name = "Leki Carbon", Number = 4001, PricePerDay = 6, Stock = 13, CategoryId = 4 }
            );
        }
    }
}
