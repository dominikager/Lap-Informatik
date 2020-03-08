using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormelOne.Models
{
    public class RacePoint
    {
        [Key]
        public int RacePointId { get; set; }

        [DisplayName("Punkte"), Range(0, 10)] // only 0 to 10 points available - dont know how it is in real life...
        public int value { get; set; }

        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public int RaceId { get; set; }
        public virtual Race Race { get; set; }

        /// <summary>
        /// Sum of Points per Season
        /// </summary>
        /// <param name="id">SeasonId</param>
        /// <returns>Point sum as Integer</returns>
        public int PointsPerSeasion(int id)
        {
            var MyContext = new MyContext();

            return MyContext.RacePoints.Where(x => x.Race.SeasonId == id).Sum(x => x.value);
        }
    }
}