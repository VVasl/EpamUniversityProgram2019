namespace Container
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Container : IContainer
    {
        private readonly IDictionary<ServiceDescriptor, object> _serviceDescriptors;

        public Container(Dictionary<ServiceDescriptor, object> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }


        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type T)
        {
            object instance = null;

            foreach (ServiceDescriptor registeredObject in _serviceDescriptors.Keys)
            {
                if (registeredObject.ServiceType == T)
                {
                    instance = CreateInstance(registeredObject);
                    break;
                }
            }

            if (instance == null)
            {
                throw new NotRegisteredException("Register \"" + T + "\" before resolving.");
            }

            return instance;
        }

        private object CreateInstance(ServiceDescriptor obj)
        {
            object instance;

            if (obj.LifeTime == ServiceLifetime.Transient || _serviceDescriptors[obj] == null)
            {
                ConstructorInfo consInfo = obj.ImplementationType.GetConstructors()[0];
                ParameterInfo[] consParams = consInfo.GetParameters();

                if (consParams.Length < 1)
                {
                    instance = Activator.CreateInstance(obj.ImplementationType);
                }
                else
                {
                    List<object> paramList = new List<object>();
                    foreach (ParameterInfo p in consParams)
                    {
                        paramList.Add(Resolve(p.ParameterType));
                    }
                    instance = consInfo.Invoke(paramList.ToArray());
                }
                _serviceDescriptors[obj] = instance;
            }
            else
            {
                instance = _serviceDescriptors[obj];
            }
            return instance;
        }
    }
}
