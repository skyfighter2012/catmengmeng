using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.NH.Core
{
    /// <summary>
    /// Entity
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Guid
        /// </summary>
        public virtual Guid Id { get; protected set; }
    }
}
