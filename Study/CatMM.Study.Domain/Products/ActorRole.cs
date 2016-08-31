using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.Domain
{
    /// <summary>
    /// Actor role
    /// </summary>
    public class ActorRole : Entity
    {
        /// <summary>
        /// Actor
        /// </summary>
        public virtual string Actor { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual string Role { get; set; }
    }
}
