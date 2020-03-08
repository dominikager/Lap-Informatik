using FormelOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormelOne.Exception;

namespace FormelOne.Repository
{
    /// <summary>
    /// The RaceRepository extends the BaseRepository
    /// </summary>
    public class RaceRepository : BaseRepository<Race>
    {
        public RaceRepository(MyContext context) : base(context)
        {
        }

        /// <summary>
        /// Max amount of Races per Year
        /// </summary>
        protected int createLimit = 20;

        /// <summary>
        /// Create new Race but only if the limit is not reached
        /// Throws a LimitReachedException if the Limit is reached
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Race Create(Race entity)
        {
            // get current amount of drivers per Team
            int driverAmountPerTeam = context.Set<Race>().Where(x => x.SeasonId == entity.SeasonId).Count();

            if (driverAmountPerTeam < createLimit)
            {
                return context.Set<Race>().Add(entity);
            }

            throw new LimitReachedException();

            return null;
        }
    }
}