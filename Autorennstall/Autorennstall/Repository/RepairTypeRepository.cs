using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class RepairTypeRepository : BaseRepository<RepairType>
    {
        public RepairTypeRepository(MyContext context) : base(context)
        {
        }
    }
}