namespace IocContainerTests
{
    using System;

    public interface IRandomGUIDProvider
    {
        Guid RandomGUID { get; }
    }
}
