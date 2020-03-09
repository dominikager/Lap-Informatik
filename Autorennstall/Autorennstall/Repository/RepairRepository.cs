using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class RepairRepository : BaseRepository<Repair>
    {
        public RepairRepository(MyContext context) : base(context)
        {
        }
        public override IEnumerable<Repair> All()
        {
            return context.Set<Repair>().Include("Driver").Include("RepairType");
        }
    }
}