using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [StringLength(200), MaxLength(200), Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Stock {
            get
            {
                var UnitOfWork = new UnitOfWork();

                return UnitOfWork.ProcessArticles.StockByArticleId(this.ArticleId);
            }
        }

        public IEnumerable<ProcessArticle> ProcessArticles { get; set; }
    }
}