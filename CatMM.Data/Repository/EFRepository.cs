using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Data.Repository
{
    /// <summary>
    /// EF repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {

        public T GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Table
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> TableNoTracking
        {
            get { throw new NotImplementedException(); }
        }
    }
}
