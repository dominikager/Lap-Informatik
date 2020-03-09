using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Repostiory
{
    public class ProcessArticleRepository : BaseRepository<ProcessArticle>
    {
        public ProcessArticleRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<ProcessArticle> FindByProcessId(int? id)
        {
            return context.ProcessArticles.Include("Process").Include("Article").Where(x => x.ProcessId == id);
        }

        public IEnumerable<ProcessArticle> All()
        {
            return this.context.Set<ProcessArticle>().Include("Process").Include("Article").ToList();
        }
    }
}