using CatMM.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.User
{
    public class Class : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
