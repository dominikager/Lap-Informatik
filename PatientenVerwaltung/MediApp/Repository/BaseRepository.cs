using MediApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediApp.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected MyContext context;

        public BaseRepository(MyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// return all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>();
        }

        /// <summary>
        /// Find One Entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindById(int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Removes a entity from db
        /// </summary>
        /// <param name="TEntity"></param>
        /// <returns></returns>
        public TEntity Remove(TEntity TEntity)
        {
            return context.Set<TEntity>().Remove(TEntity);
        }

        /// <summary>
        /// Add a new Entity
        /// </summary>
        /// <param name="TEntity"></param>
        /// <returns></returns>
        public TEntity Create(TEntity TEntity)
        {
            return context.Set<TEntity>().Add(TEntity);
        }

        /// <summary>
        /// Updates a existing entity
        /// </summary>
        /// <param name="TEntity"></param>
        public void Update(TEntity TEntity)
        {
            context.Entry(TEntity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}