using System;
using System.Runtime.Serialization;

namespace PortalEsportes.Copa.Domain.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException() { }

        public CoreException(string message) : base(message) { }

        public CoreException(string message, Exception innerException)
            : base(message, innerException) { }

        public CoreException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}
    }
}
