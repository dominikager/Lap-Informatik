using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [MaxLength(200), StringLength(200), Required]
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set;} 

        public virtual IEnumerable<Visit> Visits { get; set; }
    }
}