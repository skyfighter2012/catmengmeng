using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Events
{
    /// <summary>
    /// Event serializer interface
    /// </summary>
    public interface IEventSerializer
    {
        /// <summary>
        /// Serialize the event
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        string SerializeEvent<TEvent>(TEvent @event) where TEvent : IEvent;

        /// <summary>
        /// Deserialize the event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        IEvent DeserializeEvent(string @event);
    }
}
