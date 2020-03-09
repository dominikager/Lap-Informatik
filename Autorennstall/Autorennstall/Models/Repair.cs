using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class Repair
    {
        [Key]
        public int RepairID { get; set; }
        [Required, Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Required, MaxLength(55), Display(Name = "Notizen")]
        public string Notes { get; set; }

        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }

        public int RepairTypeID { get; set; }
        public virtual RepairType RepairType { get; set; }

        public virtual IEnumerable<RepairSparepart> RepairSparepart { get; set; }
    }
}