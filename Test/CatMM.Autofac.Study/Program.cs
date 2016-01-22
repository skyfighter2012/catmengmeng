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

            using (var scope = DIConfig.Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }

            string url = @"dd ddd-dd/dda\dddaddd/.ddad";
            Console.WriteLine(url.UrlEncode());

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
