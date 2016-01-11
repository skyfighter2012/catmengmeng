using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure
{
    /// <summary>
    /// Startup task
    /// </summary>
    public interface IStartupTask
    {
        /// <summary>
        /// Excute
        /// </summary>
        void Excute();

        /// <summary>
        /// Order
        /// </summary>
        int Order { get; }
    }
}
