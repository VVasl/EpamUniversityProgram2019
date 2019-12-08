namespace Container
{
    using System;

    public class NotRegisteredException : Exception
    {
        public NotRegisteredException() { }

        public NotRegisteredException(string message) : base(message) { }

        public NotRegisteredException(string message, Exception inner) : base(message, inner) { }
    }
}
