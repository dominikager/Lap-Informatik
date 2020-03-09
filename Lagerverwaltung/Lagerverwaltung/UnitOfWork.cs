using Lagerverwaltung.Models;
using Lagerverwaltung.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagerverwaltung
{
    /// <summary>
    /// UnitOfWork Pattern
    /// Only place for database transaction
    /// </summary>
    public class UnitOfWork : IDisposable // Implementet IDisposable so i HAVE to create a Dispose method
    {
        /// <summary>
        /// Set new Instances
        /// </summary>
        public UnitOfWork()
        {
            this.context = new MyContext();
            Articles = new ArticleRepository(context);
            ProcessArticles = new ProcessArticleRepository(context);
            Processes = new ProcessRepository(context);
            Transactions = new TransactionRepository(context);
        }

        public MyContext context { get; set; }

        public ArticleRepository Articles { get; set;}

        public ProcessArticleRepository ProcessArticles { get; set; }

        public ProcessRepository Processes { get; set; }

        public TransactionRepository Transactions { get; set; }

        /// <summary>
        /// Save the changes of the context
        /// </summary>
        /// <returns>
        /// Amount of Changes
        /// </returns>
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        /// <summary>
        /// Removes this instance from the memory
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }
    }
}