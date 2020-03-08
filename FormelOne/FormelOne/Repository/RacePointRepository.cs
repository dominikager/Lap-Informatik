using FormelOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace FormelOne.Repository
{
    /// <summary>
    /// The RacePointRepository extends the BaseRepository
    /// </summary>
    public class RacePointRepository : BaseRepository<RacePoint>
    {

        public RacePointRepository(MyContext context) : base(context)
        {

        }

        public IEnumerable<RacePoint> All()
        {
            var racePoints = context.RacePoints.Include(r => r.Driver).Include(r => r.Race);

            return racePoints;
        }

        public IEnumerable<RacePoint> Filtered(int? DriverId, int? SeasonId)
        {
            var racePoints = context.RacePoints.Include(r => r.Driver).Include(r => r.Race).Where(x => x.DriverId == DriverId && x.Race.SeasonId == SeasonId);

            return racePoints;
        }
    }
}