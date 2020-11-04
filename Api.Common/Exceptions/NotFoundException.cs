using System.Net;

namespace Api.Common.Exceptions
{
    public class NotFoundException : BaseApiException
    {
        public NotFoundException(string message) : base($@"Entity with id: {message} not found") { }
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;
    }
}
