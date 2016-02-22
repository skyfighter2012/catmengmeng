using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Singleton;

namespace CatMM.Infrastructure.Engine
{
    /// <summary>
    /// Engine context
    /// </summary>
    public class EngineContext
    {

        /// <summary>
        /// Current engine
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {

                }
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
