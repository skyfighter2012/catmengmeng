using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Domain.Presistence.NHibernate.Repository;
using CatMM.Domain.User;
using NHibernate;

namespace CatMM.Domain.Repository.NH
{
    public class CustomerRepository : NHRepository<Customer, string>
    {
        public CustomerRepository(ISession session)
            : base(session)
        {
        }
    }
}
