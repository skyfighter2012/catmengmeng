using Autofac;
using CatMM.Autofac.Study.DateWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CatMM.Autofac.Study
{
    class Program
    {
        static void Main(string[] args)
        {
            DIConfig.Register();

            DateTime now = DateTime.Now;

            string result = now.ToString("d MMMM yyyy");
            Console.WriteLine(result);
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
