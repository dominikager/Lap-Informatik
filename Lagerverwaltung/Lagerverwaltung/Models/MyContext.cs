using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Models
{
    public class MyContext : ApplicationDbContext
    {
        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Process> Processes { get; set; }

        public virtual DbSet<ProcessArticle> ProcessArticles { get; set; }

        public virtual DbSet<Transaction> Transcations { get; set; }
    }
}