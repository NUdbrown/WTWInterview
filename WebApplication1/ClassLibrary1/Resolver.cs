using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
 public class Resolver
    {
        private readonly Dictionary<Type, object> _storeRegisObjects;
        private readonly Dictionary<Type, Type> _bindRegisTypes;

        public Resolver()
        {
            _storeRegisObjects = new Dictionary<Type, object>();
            _bindRegisTypes = new Dictionary<Type, Type>();
        }

        public T Resolve<T>()
        {

            if (!_bindRegisTypes.ContainsKey(typeof(T)))
                throw new InvalidOperationException($"Requested type {typeof (T).ToString()} has not been registered.");

            Type dest = _bindRegisTypes[typeof(T)];

            if (_storeRegisObjects.ContainsKey(dest))
                return (T)_storeRegisObjects[dest];
            
            var obj =(T) Activator.CreateInstance(dest);

            _storeRegisObjects.Add(dest, obj);

            return obj;
        }

        public void Register<TService, TImpl>()
        {
            _bindRegisTypes.Add(typeof(TService), typeof(TImpl));
        }

    }
}
