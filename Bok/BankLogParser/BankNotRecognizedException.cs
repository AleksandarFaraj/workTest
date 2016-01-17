using System;
using System.Runtime.Serialization;

namespace Bok.BankLogParser
{
    [Serializable]
    internal class BankNotRecognizedException : Exception
    {
        public BankNotRecognizedException()
        {
        }

        public BankNotRecognizedException(string message) : base(message)
        {
        }

        public BankNotRecognizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankNotRecognizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}