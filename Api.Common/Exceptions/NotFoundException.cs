using System.Net;

namespace Api.Common.Exceptions
{
    public class NotFoundException : BaseApiException
    {
        public NotFoundException(string message) : base(message) { }
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;
    }
}
