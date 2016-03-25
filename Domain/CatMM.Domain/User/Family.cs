using CatMM.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.User
{
    public class Family : BaseEntity
    {
        public virtual string Address { get; set; }

        public virtual Student Student { get; set; }
    }
}
