using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.TemplateEngine.Filiters
{
    public static class TextFilter
    {
        public static string Textilize(string input)
        {
            return input.ToUpper();
        }

        public static string Default(object input, object defaultValue)
        {
            if (null != input)
            {
                return input.ToString();
            }
            else
            {
                return defaultValue.ToString();
            }
        }

        /// <summary>
        /// Format currency
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currencyLabel"></param>
        /// <returns></returns>
        public static string FormatCurrency(object input, string currencyLabel = "€")
        {
            return String.Format("{0} {1}", currencyLabel, FormatNumber(input));
        }

        /// <summary>
        /// Format number
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decimalCount"></param>
        /// <returns></returns>
        public static string FormatNumber(object input, int decimalCount = 2)
        {
            string result = String.Empty;
            if (null != input)
            {
                string format = "{0:N" + decimalCount + "}";
                result = String.Format(format, input).Replace('.', '/').Replace(',', '.').Replace('/', ',');
                result = Regex.Replace(result, "(?<=,)0+", "-");
            }
            return result;
        }
    }
}
