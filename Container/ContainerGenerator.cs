namespace Container
{
    using System.Collections.Generic;

    public class ContainerGenerator : IContainerGenerator
    {
        private readonly Dictionary<ServiceDescriptor, object> _registrations = new Dictionary<ServiceDescriptor, object>();

        /// <summary>
        /// Register types
        /// </summary>
        /// <typeparam name="Interface">Interface</typeparam>
        /// <typeparam name="Implementation">Implementing class</typeparam>
        public bool Register<Interface, Implementation>()
        {
            return Register<Interface, Implementation>(ServiceLifetime.Transient); 
        }

        /// <summary>
        /// Register types
        /// </summary>
        /// <typeparam name="Interface">Interface</typeparam>
        /// <typeparam name="Implementation">Implementing class</typeparam>
        /// <param name="lifeStyle">Lifestyle type(Transient or Singleton)</param>
        public bool Register<Interface, Implementation>(ServiceLifetime lifeStyle)
        {
            int currentCount = _registrations.Count;

            ServiceDescriptor obj = new ServiceDescriptor(typeof(Interface), typeof(Implementation), lifeStyle);
            _registrations.Add(obj, null);

            return _registrations.Count > currentCount ? true : false;
        }

        public Container GenerateContainer()
        {
            return new Container(_registrations);
        }
    }
}
