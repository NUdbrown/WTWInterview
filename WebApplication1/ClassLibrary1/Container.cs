using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Container
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();

        public void Register<TService, TImpl>() where TImpl : TService
        {
            this._registrations.Add(typeof(TService), () => this.GetInstance(typeof(TImpl)));
        }

        public object GetInstance(Type serviceType)
        {
            Func<object> creator;
            if (this._registrations.TryGetValue(serviceType, out creator)) return creator();
            else if (!serviceType.IsAbstract) return this.CreateInstance(serviceType);
            else throw new InvalidOperationException("No registration for " + serviceType);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = parameterTypes.Select(t => this.GetInstance(t)).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }


}

