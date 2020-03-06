using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiVerleih.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(255), StringLength(255), Required]
        public string Name { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
    }
}