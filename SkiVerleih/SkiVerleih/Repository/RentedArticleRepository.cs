using SkiVerleih.Exception;
using SkiVerleih.Models;
using SkiVerleih.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SkiVerleih.Repository
{
    public class RentedArticleRepository : BaseRepository<RentedArticle>
    {
        public RentedArticleRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<RentedArticleView> All()
        {
            return from c in context.Set<RentedArticle>()
                   select new RentedArticleView
                   {
                       RentedArticleViewId = c.RentedArticleId,
                       Amount = c.Amount,
                       Article = c.Article,
                       Customer = c.Customer,
                       RentedFrom = c.RentedFrom,
                       RentedTo = c.RentedTo,
                   };
        }

         /// <summary>
         /// Returns by status
         /// </summary>
         /// <param name="isRented"></param>
         /// <returns></returns>
        public IEnumerable<RentedArticleView> Filter(bool isRented, DateTime dateFrom, DateTime dateTo)
        {
            return from c in context.Set<RentedArticle>()
                   where c.IsRented == isRented && c.RentedFrom >= dateFrom && c.RentedTo <= dateTo
                   select new RentedArticleView
                   {
                       RentedArticleViewId = c.RentedArticleId,
                       Amount = c.Amount,
                       Article = c.Article,
                       Customer = c.Customer,
                       RentedFrom = c.RentedFrom,
                       RentedTo = c.RentedTo
                   };
        }

        /// <summary>
        /// Create new Rentedarticle
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public RentedArticle Create(RentedArticle entity)
        {
            entity.IsRented = true; // when creating it should be directly be rented

            if (this.CanRent(entity.ArticleId, entity.RentedFrom, entity.RentedTo, entity.Amount))
            {
                return context.Set<RentedArticle>().Add(entity);
            }

            throw new NotAvailableException();

            return null;
        }

        /// <summary>
        /// Check how many are available in a range of Dates
        /// </summary>
        /// <param name="id"></param>
        /// <param name="RentedFrom"></param>
        /// <param name="RentedTo"></param>
        /// <returns></returns>
        public int GetStock(int id, DateTime RentedFrom, DateTime RentedTo, int toRentAmount = 0)
        {
            var Article = context.Set<Article>().Find(id);

            var results = from a in context.Set<RentedArticle>()
                          where a.IsRented == true && a.ArticleId == id && a.RentedFrom >= RentedFrom && a.RentedTo <= RentedTo
                          select a;

            if (results.Count() > 0)
            {
                return Article.Stock - (results.Sum(x => x.Amount) + toRentAmount);
            }

            return Article.Stock;
        }

        /// <summary>
        /// Check if this article can be rented
        /// </summary>
        /// <param name="id"></param>
        /// <param name="RentedFrom"></param>
        /// <param name="RentedTo"></param>
        /// <returns></returns>
        public bool CanRent(int id, DateTime RentedFrom, DateTime RentedTo, int toRentAmount = 0)
        {
            int available = this.GetStock(id, RentedFrom, RentedTo, toRentAmount);

            if (available <= 0)
            {
                return false;
            }

            return true;
        }
    }
}