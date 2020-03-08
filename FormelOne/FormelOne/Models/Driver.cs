using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RacePoint> RacePoints { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}