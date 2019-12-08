namespace Container
{
    using System;

    public class ServiceDescriptor
    {
        public Type ServiceType { get; }

        public Type ImplementationType { get; set; }

        public ServiceLifetime LifeTime { get; set; }

        public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            LifeTime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            LifeTime = lifetime;
            ImplementationType = implementationType;
        }
    }
}
