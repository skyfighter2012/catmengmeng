using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Domain.Models;

namespace CatMM.Domain.User
{
    public class Customer : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
