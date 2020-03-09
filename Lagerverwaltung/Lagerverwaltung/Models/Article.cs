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

        [Required, Range(0, Int32.MaxValue)]
        public int Stock { get; set; }

        public IEnumerable<ProcessArticle> ProcessArticles { get; set; }
    }
}