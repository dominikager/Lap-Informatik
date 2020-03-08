using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [StringLength(200), MaxLength(200), Required, DisplayName("Team")]
        public string Name { get; set; }

        public virtual IEnumerable<Driver> Drivers {get; set;}

        [DisplayName("Anzahl Fahrer")]
        public int DriverAmount
        {
            get
            {
                var UnitOfWork = new UnitOfWork();
                return UnitOfWork.Drivers.CountByTeam(this.TeamId);
            }
        }
    }
}