using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Events
{
    /// <summary>
    /// Event handler interface
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        /// <summary>
        /// Handle the event
        /// </summary>
        /// <param name="event"></param>
        void Handle(TEvent @event);
    }
}
