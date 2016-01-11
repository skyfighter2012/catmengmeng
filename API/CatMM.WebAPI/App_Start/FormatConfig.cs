using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace CatMM.WebAPI
{
    /// <summary>
    /// Format config
    /// </summary>
    public class FormatConfig
    {
        /// <summary>
        /// Register formatter
        /// </summary>
        public static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
        }
    }
}