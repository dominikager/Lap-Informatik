using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class RepairType
    {
        [Key]
        public int RepairTypeID { get; set; }
        [Required, MaxLength(55), Display(Name = "Bezeichnung")]
        public string Name { get; set; }

        public virtual IEnumerable<Repair> Repairs { get; set; }
    }
}