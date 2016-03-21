using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using CatMM.Infrastructure.Domain.Models;
using CatMM.Infrastructure.Domain.Repository;
using NHibernate;
using NHibernate.Linq;
using System.Diagnostics.Contracts;


namespace CatMM.Infrastructure.Domain.Presistence.NHibernate.Repository
{
    public abstract class NHRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        private readonly ISession _session;
        private readonly int _batchSize = 20;

        protected NHRepository(ISession session, int batchSize = 20)
        {
            _session = session;
            if (batchSize < 10)
            {
                batchSize = 10;
            }
            else if (batchSize > 50)
            {
                batchSize = 50;
            }
            session.SetBatchSize(batchSize);
            _batchSize = batchSize;
        }

        public virtual ISession Session
        {
            get { return _session; }
        }



        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = Session.Query<TEntity>();
            if (null != predicate)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            Contract.Requires(null != id);
            return Session.Get<TEntity>(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Contract.Requires(null != entity);
            Session.Save(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            Contract.Requires(null != entities);
            using (ITransaction tx = Session.BeginTransaction())
            {
                int count = 0;
                foreach (TEntity entity in entities)
                {
                    count++;
                    Session.Save(entity);
                    if (count % _batchSize == 0)
                    {
                        Session.Flush();
                        Session.Clear();
                    }
                }
                tx.Commit();
            }
        }

        public virtual void Update(TEntity entity)
        {
            Contract.Requires(null != entity);
            Session.SaveOrUpdate(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            Contract.Requires(null != entities);
            using (ITransaction tx = Session.BeginTransaction())
            {
                int count = 0;
                foreach (TEntity entity in entities)
                {
                    count++;
                    Session.SaveOrUpdate(entity);
                    if (count % _batchSize == 0)
                    {
                        Session.Flush();
                        Session.Clear();
                    }
                }
                tx.Commit();
            }
        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(TPrimaryKey id)
        {
            Contract.Requires(null != id);
            TEntity entity = Get(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Contract.Requires(null != entity);
            Session.Delete(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            Contract.Requires(null != entities);
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Table
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<TEntity> TableNoTracking
        {
            get { throw new NotImplementedException(); }
        }
    }
}
