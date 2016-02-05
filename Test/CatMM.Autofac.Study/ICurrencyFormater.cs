using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Autofac.Study
{
    /// <summary>
    /// ICurrencyFormater
    /// </summary>
    public interface ICurrencyFormater
    {
        /// <summary>
        /// Format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        string Format<T>(T value, int decimalCount = 2);
    }
}
