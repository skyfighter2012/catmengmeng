using CatMM.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.Trade
{
    public partial class Product : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
