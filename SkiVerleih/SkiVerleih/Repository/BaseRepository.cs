using SkiVerleih.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiVerleih.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        public MyContext context;

        public BaseRepository(MyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// returns all entitys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>();
        }

        /// <summary>
        /// find entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindById(int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// updates a existing entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Create(TEntity entity)
        {
            return context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Removes the entity from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Remove(TEntity entity)
        {
            return context.Set<TEntity>().Remove(entity);
        }
    }
}