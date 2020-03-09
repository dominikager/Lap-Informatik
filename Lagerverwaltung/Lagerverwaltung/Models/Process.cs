using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Models
{
    public class Process
    {
        [Key]
        public int ProcessId { get; set; }

        [StringLength(200), MaxLength(200), Required]
        public string Name { get; set; }

        [Required]
        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; } // Vorgangstyp

        public IEnumerable<ProcessArticle> ProcessArticles { get; set; }
    }
}