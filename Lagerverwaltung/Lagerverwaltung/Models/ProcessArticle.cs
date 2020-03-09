using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Models
{
    public class ProcessArticle
    {
        [Key]
        public int ProcessArticleId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int ProcessId { get; set; }

        [Required, Range(1, Int32.MaxValue)]
        public int Amount { get; set; }

        public Article Article { get; set; }

        public Process Process { get; set; }
    }
}