using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.Domain
{
    /// <summary>
    /// Movie
    /// </summary>
    public class Movie : Product
    {
        /// <summary>
        /// Director
        /// </summary>
        public virtual string Director { get; set; }

        /// <summary>
        /// Actor role
        /// </summary>
        public virtual IList<ActorRole> Actors { get; set; }
    }
}
