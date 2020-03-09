using Autorennstall.Models;
using Autorennstall.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall
{
    public class UnitOfWork : IDisposable
    {
        public DriverRepository Drivers { get; }
        public TeamRepository Teams { get; }
        public SparepartRepository Spareparts { get; }
        public RepairTypeRepository RepairTypes { get; }
        public RepairRepository Repairs { get; }
        public RepairSparepartRepository RepairSpareparts { get; }

        public MyContext context;

        public UnitOfWork()
        {
            this.context = new MyContext();
            Drivers = new DriverRepository(context);
            Teams = new TeamRepository(context);
            Spareparts = new SparepartRepository(context);
            RepairTypes = new RepairTypeRepository(context);
            Repairs = new RepairRepository(context);
            RepairSpareparts = new RepairSparepartRepository(context);
        }

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