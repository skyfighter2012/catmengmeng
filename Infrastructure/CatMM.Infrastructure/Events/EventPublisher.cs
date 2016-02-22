using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Events
{
    /// <summary>
    /// Event publisher
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        private readonly ISubscriptionService _subscriptionService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="subscriptionService"></param>
        public EventPublisher(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        protected virtual void PublishToConsumer<T>(IConsumer<T> consumer, T eventMessage)
        {
            //Find all types that implement IConsumer<T>

            //Invoke HandleEvent of each implemented types;

        }

        /// <summary>
        /// Publish event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventMessage">event message</param>
        public virtual void Publish<T>(T eventMessage)
        {
            var subscriptions = _subscriptionService.GetSubscriptions<T>();
            subscriptions.ToList().ForEach(it => PublishToConsumer<T>(it, eventMessage));
        }
    }
}
