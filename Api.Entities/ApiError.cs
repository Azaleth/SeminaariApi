using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Api.Entities
{
    public class ApiError
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }

        public ApiError(string message)
        {
            this.message = message;
            isError = true;
        }
    }
}
