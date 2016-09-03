using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CourseApi.V2.Repositories.DAL;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.V2.Repositories.Base
{
    public abstract class RepositoryBase<T> where T : class
    {
        private CourseDbContext context;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get; private set;
        }

        protected CourseDbContext DbContext => context ?? (context = DbFactory.Init());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public DbSet<T> ReturnDbSet()
        {
            return dbSet;
        }
    }
}
