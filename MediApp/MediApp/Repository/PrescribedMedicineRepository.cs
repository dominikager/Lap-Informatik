using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediApp.Models;
using MediApp.ViewModels;

namespace MediApp.Repository
{
    public class PrescribedMedicineRepository : BaseRepository<PrescribedMedicine>
    {
        public PrescribedMedicineRepository(MyContext context) : base(context)
        {
        }
    }
}