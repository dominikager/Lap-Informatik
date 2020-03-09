using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class SparepartRepository : BaseRepository<Sparepart>
    {
        public SparepartRepository(MyContext context) : base(context)
        {
        }
    }
}