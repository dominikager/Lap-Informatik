using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class Sparepart
    {
        [Key]
        public int SparepartID { get; set; }
        [Required, MaxLength(55)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, Range(0, Int32.MaxValue)]
        public int Amount { get; set; }

        public virtual IEnumerable<RepairSparepart> RepairSparepart { get; set; }
    }
}