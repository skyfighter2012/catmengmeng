using Autofac;
using CatMM.Autofac.Study.DateWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.ReadKey();
        }


    }
}
