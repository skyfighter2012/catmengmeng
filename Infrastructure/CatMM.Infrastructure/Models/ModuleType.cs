using DotLiquid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Models
{
    public enum ModuleType
    {
        /// <summary>
        /// Search module
        /// </summary>
        [Description("Search module")]
        SearchModule = 0,

        /// <summary>
        /// Service module
        /// </summary>
        [Description("Service module")]
        ServiceModule = 1,

        /// <summary>
        /// Management module
        /// </summary>
        [Description("Management module")]
        ManagementModule = 3
    }
}
