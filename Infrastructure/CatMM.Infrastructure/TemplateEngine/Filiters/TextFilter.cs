using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
