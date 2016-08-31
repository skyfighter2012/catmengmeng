using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.Domain.Accounts
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual AccountType AcctType { get; set; }
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
    }
}
