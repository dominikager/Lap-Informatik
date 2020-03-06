using SkiVerleih.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiVerleih.Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(MyContext context) : base(context)
        {
        }
    }
}