using FormelOne.Models;
using System.Collections.Generic;
using System.Linq;

namespace FormelOne.Repository
{
    /// <summary>
    /// This generic Repostiory contains all basic functions that other Repositories will need.
    /// </summary>
    /// <typeparam name="TEntity">Generic Class</typeparam>
    public class BaseRepository<TEntity> where TEntity : class
    {
        public MyContext context;

        public BaseRepository(MyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Aamount of entity
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.All().Count();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// A list of entities
        /// </returns>
        public IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>();
        }

        /// <summary>
        /// Find a Entity by Primary Key
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>
        /// The founded Entity
        /// </returns>
        public TEntity Find(int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Remove a entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <returns>Will return the delted entity</returns>
        public TEntity Remove(TEntity entity)
        {
            return context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Add the Entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <returns>It will return the entity object with the primary key from  the database</returns>
        public TEntity Create(TEntity entity)
        {
            return context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Update the database entry by the given object
        /// </summary>
        /// <param name="entity">Entity object</param>
        public void Update(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}