using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }

        [Required, DisplayName("Datum")]
        public DateTime Date { get; set; }

        [MaxLength(300), StringLength(300), DisplayName("Kommentar")]
        public string Comment { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public virtual IEnumerable<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}