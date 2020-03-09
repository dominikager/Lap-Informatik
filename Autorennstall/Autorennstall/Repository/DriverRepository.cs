using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class DriverRepository : BaseRepository<Driver>
    {
        public DriverRepository(MyContext context) : base(context)
        {
        }
    }
}