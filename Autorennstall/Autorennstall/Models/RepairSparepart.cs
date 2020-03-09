using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class RepairSparepart
    {
        [Key]
        public int RepairSparepartID { get; set; }
        public int RepairID { get; set; }
        public int SparepartID { get; set; }

        public virtual Sparepart Sparepart { get; set; }
        public virtual Repair Repair { get; set; }
    }
}