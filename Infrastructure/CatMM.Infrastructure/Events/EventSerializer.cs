using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CatMM.Infrastructure.Events
{
    /// <summary>
    /// Event serializer
    /// </summary>
    public class EventSerializer : IEventSerializer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static EventSerializer()
        {
            DefaultSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                TypeNameHandling = TypeNameHandling.All
            };
        }

        /// <summary>
        /// Json serializer default settings
        /// </summary>
        public static JsonSerializerSettings DefaultSettings { get; private set; }

        /// <summary>
        /// Serialize the event
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        public string SerializeEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return JsonConvert.SerializeObject(@event, DefaultSettings);
        }

        /// <summary>
        /// Deserialize the event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public IEvent DeserializeEvent(string @event)
        {
            return JsonConvert.DeserializeObject<IEvent>(@event, DefaultSettings);
        }
    }
}
