using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class Season
    {
        [Key]
        public int SeasonId { get; set; }

        [Required, DisplayName("Jahr")]
        public int Year { get; set; }

        public virtual IEnumerable<Race> Races { get; set; }
    }
}