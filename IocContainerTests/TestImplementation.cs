namespace IocContainerTests
{
    using System;

    internal class TestImplementation : ITestInterface
    {
        private readonly IRandomGUIDProvider _randomGUIDProvider;

        public TestImplementation(IRandomGUIDProvider randomGUIDProvider)
        {
            _randomGUIDProvider = randomGUIDProvider;
        }

        public void PrintSomething()
        {
            Console.WriteLine(_randomGUIDProvider.RandomGUID);
        }
    }
}
