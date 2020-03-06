using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.ViewModels
{
    public class PrescribedMedicineView
    {
        [Key]
        public int PrescribedMedicineId { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }
    }
}