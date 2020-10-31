using System.Net;

namespace Api.Common.Exceptions
{
    public class InvalidRequestException : BaseApiException
    {
        public InvalidRequestException(string message) : base(message) { }
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    }
}
