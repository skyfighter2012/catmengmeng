using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Singleton
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class Singleton
    {
        private static readonly IDictionary<Type, object> allSingletons;

        /// <summary>
        /// Static constructor
        /// </summary>
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// All singletons
        /// </summary>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }

    /// <summary>
    /// Singleton
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : Singleton
    {
        static T instance;

        /// <summary>
        /// Instance;
        /// </summary>
        public static T Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
}
