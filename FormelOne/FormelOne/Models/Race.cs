using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }

        [Required, StringLength(200), MaxLength(200)]
        public string Name { get; set; }

        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }

        public virtual ICollection<RacePoint> RacePoints { get; set; }
    }
}