using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.Dependency;

namespace CatMM.Infrastructure.Engine
{
    /// <summary>
    /// Catmm engine
    /// </summary>
    public class CatMMEngine : IEngine
    {
        private ContainerManager _containerManager;

        


        public Dependency.ContainerManager ContainerManager
        {
            get { throw new NotImplementedException(); }
        }

        public void Initialize(Configuration.AppConfig config)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
