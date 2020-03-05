using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediApp.Models;

namespace MediApp.Repository
{
    public class DoctorRepository : BaseRepository<Doctor>
    {
        public DoctorRepository(MyContext context) : base(context)
        {
        }
    }
}