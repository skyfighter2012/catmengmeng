using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Shared.Enums
{
    /// <summary>
    /// Sex
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Male
        /// </summary>
        [Description("Male")]
        Male,

        /// <summary>
        /// Female
        /// </summary>
        [Description("Female")]
        Female
    }
}
