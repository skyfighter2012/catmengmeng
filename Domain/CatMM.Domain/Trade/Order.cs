using CatMM.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.Trade
{
    public class Order : BaseEntity
    {
        public virtual string CustomerId { get; set; }

        public virtual DateTime? UtcCreatedOn { get; set; }
    }
}
