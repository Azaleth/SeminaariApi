using System;
using System.Net;

namespace Api.Common.Exceptions
{
    public abstract class BaseApiException : Exception
    {
        public BaseApiException(string message) : base(message) { }
        public abstract HttpStatusCode HttpStatusCode { get; }
    }
}
