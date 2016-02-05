using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Extensions
{
    public static class NumberExtensions
    {
        public static string FormatCurrency<T>(this T value, int decimalCount = 2)
        {
            if (null == value)
            {
                throw new NullReferenceException();
            }

            if (!typeof(ValueType).IsAssignableFrom(value.GetType()))
            {
                throw new NotImplementedException();
            }

            string format = "{0:N" + decimalCount + "}";
            string result = String.Format(format, value).Replace('.', '/').Replace(',', '.').Replace('/', ',');
            return result;
        }
    }
}
