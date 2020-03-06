using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.Models
{
    public class PrescribedMedicine
    {
        [Key]
        public int PrescribedMedicineId { get; set; }

        [Range(1, 20)]
        public int Amount { get; set; }

        public int VisitId { get; set; }
        public virtual Visit Visit { get; set; }

        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}