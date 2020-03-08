using FormelOne.Models;
using FormelOne.Exception;
using System.Linq;

namespace FormelOne.Repository
{
    /// <summary>
    /// The DriverRepository extends the BaseRepository
    /// </summary>
    public class DriverRepostiory : BaseRepository<Driver>
    {
        public DriverRepostiory(MyContext context) : base(context)
        {
        }

        /// <summary>
        /// Max amount of driver per Team
        /// </summary>
        protected int createLimit = 2;

        /// <summary>
        /// Create Driver but only if the limit is not reached
        /// If the limit is reached it throws an exception
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Driver Create(Driver entity)
        {
            // get current amount of drivers per Team

            if (this.CountByTeam(entity.TeamId) < createLimit)
            {
                return context.Set<Driver>().Add(entity);
            }

            throw new LimitReachedException();

            return null;
        }

        public int CountByTeam(int id) {
           return context.Set<Driver>().Where(x => x.TeamId == id).Count();
        }
    }
}