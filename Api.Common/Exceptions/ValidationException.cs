using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Api.Common.Exceptions
{
    public class ValidationException : BaseApiException
    {
        public ValidationException(string message) : base(message)
        { }
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    }
}
