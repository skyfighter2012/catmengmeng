using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Models
{
    public class User : Drop
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
    }
}
