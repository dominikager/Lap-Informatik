using SkiVerleih.Models;
using SkiVerleih.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiVerleih
{
    /// <summary>
    /// implementing IDisposable so i HAVE to implement a Dispose method
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
            context = new MyContext();
            RentedArticles = new RentedArticleRepository(context);
            Categories = new CategoryRepository(context);
            Customers = new CustomerRepository(context);
            Articles = new ArticleRepository(context);
        }

        public RentedArticleRepository RentedArticles { get; }

        public CategoryRepository Categories { get; }

        public CustomerRepository Customers { get; }

        public ArticleRepository Articles { get; }

        public MyContext context;

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}