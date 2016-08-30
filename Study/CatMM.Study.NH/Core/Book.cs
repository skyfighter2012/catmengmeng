using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.NH.Core
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book : Product
    {
        /// <summary>
        /// ISBN
        /// </summary>
        public virtual string ISBN { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public virtual string Author { get; set; }
    }
}
