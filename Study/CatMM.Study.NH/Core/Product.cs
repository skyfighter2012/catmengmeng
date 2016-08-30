using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.NH.Core
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public virtual decimal UnitPrice { get; set; }
    }
}
