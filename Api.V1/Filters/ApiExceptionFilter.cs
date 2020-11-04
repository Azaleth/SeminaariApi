using Api.Common.Exceptions;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.V1.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            if (context.Exception is BaseApiException exception)
            {                
                context.Exception = null;
                apiError = new ApiError(exception.Message);

                context.HttpContext.Response.StatusCode = (int)exception.HttpStatusCode;
                context.ExceptionHandled = true;
            }
            else
            {
                // Unhandled errors
#if !DEBUG
                var msg = "An unhandled error occurred.";                
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg);
                apiError.Detail = stack;

                context.HttpContext.Response.StatusCode = 500;
            }
            context.Result = new ObjectResult(apiError);
            base.OnException(context);
        }
    }
}
