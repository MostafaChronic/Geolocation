using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //-------Definition Public Functions Models-----------//
        void Insert(TEntity entity);
        void CreateAsync(TEntity entity);
        void Update(TEntity entity);

        void Delete(object Id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "");
        TEntity GetById(object Id);
        TEntity Find(Expression<Func<TEntity, bool>> where);

        //---------------Async Functions----------------//
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "");
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
    }
}
