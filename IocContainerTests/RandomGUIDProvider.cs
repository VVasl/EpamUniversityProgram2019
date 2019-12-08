namespace IocContainerTests
{
    using System;

    public class RandomGUIDProvider : IRandomGUIDProvider
    {
        public Guid RandomGUID { get; } = Guid.NewGuid();
    }
}
