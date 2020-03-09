using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(MyContext context) : base(context)
        {
        }
    }
}