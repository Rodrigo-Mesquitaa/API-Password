using Microsoft.EntityFrameworkCore;
using Password.Domian.Core.Interfaces.Repositories;
using Password.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Password.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            sqlContext.Set<TEntity>().Add(obj);
            sqlContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            sqlContext.Set<TEntity>().Remove(obj);
            sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            sqlContext.Entry(obj).State = EntityState.Modified;
            sqlContext.SaveChanges();
        }
    }
}