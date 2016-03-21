using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Domain.Models;
using System.Linq.Expressions;

namespace CatMM.Infrastructure.Domain.Repository
{
    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity, in TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// Insert entitys
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="id"></param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }
    }
}
