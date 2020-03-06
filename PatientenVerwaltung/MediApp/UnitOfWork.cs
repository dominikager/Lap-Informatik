using MediApp.Models;
using MediApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediApp
{
    // implements the Interface Disposable, so i HAVE to implement a logic for Dispose
    public class UnitOfWork : IDisposable
    {
        public MyContext context;

        public UnitOfWork()
        {
            this.context = new MyContext();
            Visits = new VisitRepository(context);
            Doctors = new DoctorRepository(context);
            Medicines = new MedicineRepository(context);
            PrescribedMedicines = new PrescribedMedicineRepository(context);
        }

        public VisitRepository Visits { get; }

        public DoctorRepository Doctors { get; }

        public PrescribedMedicineRepository PrescribedMedicines { get; }

        public MedicineRepository Medicines { get; }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}