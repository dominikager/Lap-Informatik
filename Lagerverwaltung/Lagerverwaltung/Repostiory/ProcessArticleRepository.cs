using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int StockByArticleId(int? id)
        {
            int IncomingAmount = 0;
            int OutgoingAmount = 0;

            var Incoming = this.context.Set<ProcessArticle>().Where(x => x.ArticleId == id && x.Process.TransactionId == 1);
            var Outgoing = this.context.Set<ProcessArticle>().Where(x => x.ArticleId == id && x.Process.TransactionId == 2);

            if (Incoming.Count() > 0)
            {
                IncomingAmount = Incoming.Sum(x => x.Amount);
            }

            if (Outgoing.Count() > 0)
            {
                OutgoingAmount = Outgoing.Sum(x => x.Amount);
            }

            Debug.WriteLine(IncomingAmount);

            Debug.WriteLine(OutgoingAmount);

            return IncomingAmount - OutgoingAmount;
        }
    }
}