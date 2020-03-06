using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiVerleih.Models
{
    public class RentedArticle
    {
        [Key]
        public int RentedArticleId { get; set; }

        [Range(1, Int32.MaxValue), DisplayName("Anzahl")] // because nobody should rent 0 snowboards... ;-)
        public int Amount { get; set; }

        [Required, DisplayName("Ausleihen von")]
        public DateTime RentedFrom { get; set; }

        [Required, DisplayName("Ausleihen bis")]
        public DateTime RentedTo { get; set; }

        public bool IsRented { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}