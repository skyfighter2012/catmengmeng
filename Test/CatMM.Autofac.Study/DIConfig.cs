using Autofac;
using CatMM.Autofac.Study.DateWriter;
using CatMM.Autofac.Study.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Autofac.Study
{
    public class DIConfig
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutPut>().As<IOutPut>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            _container = builder.Build();
        }
    }
}
