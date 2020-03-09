using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorennstall.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        [Display(Name = "Vorname"), Required, MaxLength(55)]
        public string FName { get; set; }
        [Display(Name = "Nachname"), Required, MaxLength(55)]
        public string LName { get; set; }
        [Required]
        public bool Active { get; set; }

        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        public virtual IEnumerable<Repair> Repairs { get; set; }
        [Display(Name = "Fahrer")]
        public string FullName { get { return FName + " " + LName; } }
    }
}