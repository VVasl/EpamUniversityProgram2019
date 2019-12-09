namespace Container
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotRegisteredException : Exception
    {
        public NotRegisteredException() { }

        public NotRegisteredException(string message) : base(message) { }

        public NotRegisteredException(string message, Exception inner) : base(message, inner) { }

        protected NotRegisteredException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
