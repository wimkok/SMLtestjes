using System;
using System.Runtime.Serialization;

namespace SMLtestjes
{
    [Serializable]
    internal class TypeIDException : Exception
    {
        public TypeIDException()
        {
        }

        public TypeIDException(string message) : base(message)
        {
        }

        public TypeIDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TypeIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}