using Autorennstall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autorennstall.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected MyContext context;

        public BaseRepository(MyContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>();
        }

        public TEntity FindByID (int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Remove (TEntity TEntity)
        {
            return context.Set<TEntity>().Remove(TEntity);
        }

        public TEntity Create (TEntity TEntity)
        {
            return context.Set<TEntity>().Add(TEntity);
        }

        public void Update(TEntity TEntity)
        {
            context.Entry(TEntity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}