using FormelOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormelOne.Exception;

namespace FormelOne.Repository
{
    /// <summary>
    /// The TeamRepository extends the BaseRepository
    /// </summary>
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(MyContext context) : base(context)
        {
        }

        /// <summary>
        /// Create Limit
        /// </summary>
        protected int createLimit = 12;

        /// <summary>
        /// Will add the entity only if its under the Limit
        /// If the Limit is reached an LimitReachedException will be thrown
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Team Create(Team entity)
        {
            if(this.Count() < createLimit)
            {
                return context.Set<Team>().Add(entity);
            }

            throw new LimitReachedException();

            return null;
        }
    }
}