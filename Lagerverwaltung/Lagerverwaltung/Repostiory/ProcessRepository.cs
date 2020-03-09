using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lagerverwaltung.Models;

namespace Lagerverwaltung.Repostiory
{
    public class ProcessRepository : BaseRepository<Process>
    {
        public ProcessRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<Process> All()
        {
            return this.context.Set<Process>().Include("Transaction").ToList();
        }
    }
}