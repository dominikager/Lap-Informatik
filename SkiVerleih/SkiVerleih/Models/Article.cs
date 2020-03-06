using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiVerleih.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [MaxLength(255), StringLength(255), DisplayName("Name"), Required]
        public string Name { get; set; }

        [Required, DisplayName("Artikelnummer")]
        public int Number { get; set; }

        [Required, DisplayName("Preis pro Tag")]
        public decimal PricePerDay { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IEnumerable<RentedArticle> RentedArticles { get; set; }
    }
}