using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Repostiory
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(MyContext context) : base(context)
        {
        }
    }
}