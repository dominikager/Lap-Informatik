using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class RepairSparepartRepository : BaseRepository<RepairSparepart>
    {
        public RepairSparepartRepository(MyContext context) : base(context)
        {
        }

        public override IEnumerable<RepairSparepart> All()
        {
            return context.Set<RepairSparepart>().Include("Repair").Include("Sparepart");
        }

        public IEnumerable<RepairSparepart> FindByRepairID(int? id)
        {
            return context.Set<RepairSparepart>().Include("Repair").Include("Sparepart").Where(x => x.RepairID == id);
        }
    }
}