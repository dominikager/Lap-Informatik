using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lagerverwaltung.Models;

namespace Lagerverwaltung.Repostiory
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(MyContext context) : base(context)
        {
        }
    }
}
