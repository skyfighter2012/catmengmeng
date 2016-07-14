using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Events;

namespace CatMM.Events
{
    public class HerEvent : EventBase
    {
        public int Id { get; set; }
    }
}
