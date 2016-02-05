using Autofac;
using CatMM.Autofac.Study.DateWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using CatMM.Infrastructure.Extensions;

namespace CatMM.Autofac.Study
{
    class Program
    {
        static void Main(string[] args)
        {
            DIConfig.Register();

            DateTime now = DateTime.Now;

            //string result = now.ToString("d MMMM yyyy");
            //Console.WriteLine(result);



            ICurrencyFormater formater = new CurrencyFormater();
            double value = 123456.123443434;

            Console.WriteLine(value.FormatCurrency(6));
            Console.ReadKey();
        }
    }


    public static class StringExtensions
    {
        public static string UrlEncode(this string url)
        {
            return HttpUtility.HtmlEncode(url);
        }

    }
}
