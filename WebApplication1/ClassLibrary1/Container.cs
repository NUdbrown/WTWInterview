using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Container
    {
    
        private static Resolver _resolverInstance = null;

        public static void Register<TService, TImpl>()
        {
            GetInstance().Register<TService, TImpl>();
        }

        public static T Resolve<T>()
        {
            return GetInstance().Resolve<T>();
        }

        private static Resolver GetInstance()
        {
            return _resolverInstance ?? (_resolverInstance = new Resolver());
        }
    }


}

