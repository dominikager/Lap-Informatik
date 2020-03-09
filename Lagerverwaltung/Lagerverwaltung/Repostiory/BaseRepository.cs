using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Repostiory
{
    /// <summary>
    /// Generic BaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Context variable
        /// </summary>
        protected MyContext context;

        /// <summary>
        /// Set the context in this scope
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(MyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Fetching All Entities
        /// </summary>
        /// <returns>
        /// List with all Entities
        /// </returns>
        public IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>();
        }

        /// <summary>
        /// Find Entity by Primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return generic Class
        /// </returns>
        public TEntity Find(int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Remove Entity from Context
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return generic Class
        /// </returns>
        public TEntity Remove(TEntity entity)
        {
            return context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Add Entity to Context
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return generic Class
        /// </returns>
        public TEntity Create(TEntity entity)
        {
            return context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Update an Existing an Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}