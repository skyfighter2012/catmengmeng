using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace CatMM.Infrastructure.Events
{
    public class ServiceBusEventReceiver
    {
        private IEventSerializer _eventSerializer = new EventSerializer();

        /// <summary>
        /// Receive an event message
        /// </summary>
        /// <param name="eventMessage"></param>
        protected void ReceiveEvent(BrokeredMessage eventMessage)
        {
            string eventMessageBody = eventMessage.GetBody<string>();
            Contract.Assert(!String.IsNullOrWhiteSpace(eventMessageBody));

            IEvent @event = _eventSerializer.DeserializeEvent(eventMessageBody);
            Contract.Assert(@event != null);

            try
            {
                ReceiveEvent(@event);

                // Remove the message from service bus
                eventMessage.Complete();
            }
            catch (Exception ex)
            {

                // Indicates a problem, unlock the message in service bus
                eventMessage.Abandon();
            }
        }

        /// <summary>
        /// Receive an event
        /// </summary>
        /// <param name="event"></param>
        public void ReceiveEvent(IEvent @event)
        {
            Type eventHandlerType = typeof(IEventHandler<>);
            eventHandlerType = eventHandlerType.MakeGenericType(@event.GetType());

            Type enumerableEventHandlerType = typeof(IEnumerable<>);
            enumerableEventHandlerType = enumerableEventHandlerType.MakeGenericType(eventHandlerType);

            object eventHandlers = null;


            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies().Where(it => it.FullName.Contains("EventHandler")).ToArray();
            List<Type> allTypes = new List<Type>();

            asms.ToList().ForEach(it =>
            {
                allTypes.AddRange(it.GetTypes());
            });

            var targetType = allTypes.Where(it => it.Name == "MainEventHandler").FirstOrDefault();

            var eventHandler = Activator.CreateInstance(targetType);
            MethodInfo eventHandlerTypeHandleMethodInfo = eventHandlerType.GetMethod("Handle");
            eventHandlerTypeHandleMethodInfo.Invoke(eventHandler, new object[] { @event });

            //if (_componentContext.TryResolve(enumerableEventHandlerType, out eventHandlers))
            //{
            //    MethodInfo eventHandlerTypeHandleMethodInfo = eventHandlerType.GetMethod("Handle");

            //    foreach (object eventHandler in (IEnumerable)eventHandlers)
            //    {
            //        eventHandlerTypeHandleMethodInfo.Invoke(eventHandler, new object[] { @event });
            //    }
            //}
        }
    }
}
