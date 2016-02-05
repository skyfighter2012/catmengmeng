using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CatMM.Autofac.Study
{
    public class CurrencyFormater : ICurrencyFormater
    {
        public string Format<T>(T value, int decimalCount = 2)
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
            string result = string.Format(format, value);
            //Regex regex = new Regex(@"(?<=\d)(?=(\d{3})+(?!\d))");
            //string result = regex.Replace(value.ToString(), ",");
            return result;
        }
    }
}
