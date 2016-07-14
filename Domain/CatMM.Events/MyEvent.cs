using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Events;

namespace CatMM.Events
{
    public class MyEvent : EventBase
    {
        public string Id { get; set; }
    }
}
