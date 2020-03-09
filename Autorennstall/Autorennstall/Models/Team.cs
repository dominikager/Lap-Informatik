using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required, MaxLength(55)]
        public string Name { get; set; }
        [Required, Display(Name = "Eintrittsdatum")]
        public DateTime EntryDate { get; set; }

        public virtual IEnumerable<Driver> Drivers { get; set; }
    }
}