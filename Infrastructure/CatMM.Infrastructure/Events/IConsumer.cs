using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Events
{
    /// <summary>
    /// Event consumer
    /// </summary>
    public interface IConsumer<T>
    {
        /// <summary>
        /// Handle event
        /// </summary>
        /// <param name="eventMessage"></param>
        void HandleEvent(T eventMessage);
    }
}
