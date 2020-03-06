using MediApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediApp.ViewModels
{
    public class VisitWithPrescribedMedicines
    {
        [Key]
        public int VisitWithPrescribedMedicinesId { get; set; }

        public IEnumerable<PrescribedMedicineView> PrescribedMedicines { get; set; }

        public Visit Visit { get; set; }

        public PrescribedMedicine PrescribedMedicine { get; set; }
    }
}