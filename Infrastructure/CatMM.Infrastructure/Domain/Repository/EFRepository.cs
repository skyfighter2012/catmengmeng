using CatMM.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Domain.Repository
{
    /// <summary>
    /// EF repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (null == _entities)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public EFRepository(IDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetById(object Id)
        {
            return this.Entities.Find(Id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            Contract.Assert(null != entity);
            ThrowIfNotSuccessful(() =>
            {
                this.Entities.Add(entity);
                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            Contract.Assert(null != entities);
            ThrowIfNotSuccessful(() =>
            {
                foreach (T entity in entities)
                {
                    this.Entities.Add(entity);
                }

                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            Contract.Assert(null != entity);
            ThrowIfNotSuccessful(() =>
            {
                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        public void Update(IEnumerable<T> entities)
        {
            Contract.Assert(null != entities);
            ThrowIfNotSuccessful(() =>
            {
                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            Contract.Assert(null != entity);
            ThrowIfNotSuccessful(() =>
            {
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            Contract.Assert(null != entities);
            ThrowIfNotSuccessful(() =>
            {
                foreach (T entity in entities)
                {
                    this.Entities.Remove(entity);
                }

                this._context.SaveChanges();
            });
        }

        /// <summary>
        /// Table
        /// </summary>
        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Throw if not successful
        /// </summary>
        /// <param name="action"></param>
        private void ThrowIfNotSuccessful(Action action)
        {
            try
            {
                action();
            }
            catch (DbEntityValidationException dbEx)
            {
                StringBuilder msgSb = new StringBuilder();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msgSb.Append(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine);
                    }
                }

                throw new Exception(msgSb.ToString(), dbEx);
            }
        }
    }
}
