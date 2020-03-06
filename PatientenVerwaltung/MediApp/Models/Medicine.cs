using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [StringLength(200), MaxLength(200)]
        public string Name { get; set; }

        public virtual IEnumerable<PrescribedMedicine> PrescribedMedicines { get; set;}
    }
}