using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.User
{
    public class CustomerRole
    {

        public virtual Customer Customer { get; set; }

        public virtual Role Role { get; set; }

        public virtual bool IsActive { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
