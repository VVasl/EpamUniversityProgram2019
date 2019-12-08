namespace IocContainerTests
{
    using NUnit.Framework;
    using Container;

    public class RegisterTests
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
        public void TestRegisterWithoutParams()
        {
            bool result = service.Register<ITestInterface, TestImplementation>();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestRegisterWithParams()
        {
            bool result = service.Register<ITestInterface, TestImplementation>(ServiceLifetime.Transient);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestRegisterWithTransient()
        {
            service.Register<ITestInterface, TestImplementation>(ServiceLifetime.Transient);
            service.Register<IRandomGUIDProvider, RandomGUIDProvider>();

            ITestInterface firstRepo = container.Resolve<ITestInterface>();
            ITestInterface secondRepo = container.Resolve<ITestInterface>();

            Assert.IsFalse(ReferenceEquals(firstRepo, secondRepo));
        }

        [Test]
        public void TestRegisterWithSingleton()
        {
            service.Register<ITestInterface, TestImplementation>(ServiceLifetime.Singleton);
            service.Register<IRandomGUIDProvider, RandomGUIDProvider>();

            ITestInterface firstRepo = container.Resolve<ITestInterface>();
            ITestInterface secondRepo = container.Resolve<ITestInterface>();

            Assert.IsTrue(ReferenceEquals(firstRepo, secondRepo));
        }
    }
}