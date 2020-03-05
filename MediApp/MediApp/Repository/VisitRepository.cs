using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediApp.Models;
using MediApp.ViewModels;

namespace MediApp.Repository
{
    public class VisitRepository : BaseRepository<Visit>
    {
        public VisitRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<Visit> Filter(string from, string to, int? doctorId)
        {
            DateTime dateFrom = DateTime.Parse(from);
            DateTime dateTo = DateTime.Parse(to);

            return from c in this.All()
                   where c.Date >= dateFrom && c.Date <= dateTo && c.DoctorId == doctorId
                   select c;
        }

        public IEnumerable<PrescribedMedicineView> PrescribedMedicines(int? id)
        {
            return from c in context.Set<PrescribedMedicine>()
                   where c.VisitId == id
                   select new PrescribedMedicineView()
                   {
                       PrescribedMedicineId = c.PrescribedMedicineId,
                       Amount = c.Amount,
                       Name = c.Medicine.Name
                   };
        }
    }
}