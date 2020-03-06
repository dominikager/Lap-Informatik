using SkiVerleih.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiVerleih.ViewModels
{
    public class RentedArticleView
    {
        [Key]
        public int RentedArticleViewId { get; set; }

        public Article Article { get; set; }

        public Customer Customer { get; set; }

        public int Amount { get; set; }

        public DateTime RentedFrom { get; set; }

        public DateTime RentedTo { get; set; }
    }
}