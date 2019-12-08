namespace IocContainerTests
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using Container;

    class ResolveTests
    {
        private IContainerGenerator service;
        private IContainer container;

        [SetUp]
        public void Setup()
        {
            service = new ContainerGenerator();

            container = service.GenerateContainer();
        }

        [Test]
        public void UnregisteredRequestForLifeStyleThrowsException()
        {
            ActualValueDelegate<object> testDelegate = () => container.Resolve<IRandomGUIDProvider>();

            Assert.That(testDelegate, Throws.TypeOf<NotRegisteredException>());
        }

        [Test]
        public void CanResolveInstance()
        {
            service.Register<IRandomGUIDProvider, RandomGUIDProvider>();

            IRandomGUIDProvider result = container.Resolve<IRandomGUIDProvider>();

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanResolveParameterizedConstructor()
        {
            service.Register<ITestInterface, TestImplementation>();
            service.Register<IRandomGUIDProvider, RandomGUIDProvider>();

            ITestInterface result = container.Resolve<ITestInterface>();

            Assert.IsNotNull(result);
        }
    }
}
