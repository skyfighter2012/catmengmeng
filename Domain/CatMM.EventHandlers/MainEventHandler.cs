using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Events;
using CatMM.Infrastructure.Events;

namespace CatMM.EventHandlers
{
    public class MainEventHandler :
        IEventHandler<HerEvent>,
        IEventHandler<MyEvent>,
        IEventHandler<OtherEvent>
    {

        public void Handle(HerEvent @event)
        {
            Console.WriteLine("her event");
        }

        public void Handle(MyEvent @event)
        {
            Console.WriteLine("my event");
        }


        public void Handle(OtherEvent @event)
        {
            Console.WriteLine("other event");
        }
    }
}
