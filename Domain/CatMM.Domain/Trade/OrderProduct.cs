using CatMM.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.Trade
{
    public class OrderProduct : IEntity
    {
        public virtual string OrderId { get; set; }

        public virtual string ProductId { get; set; }
    }
}
