using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SmartEssentials.WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private ILogger _logger { get; set; }

        public ExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var message = "Server error occurred.";

            var exceptionType = context.Exception.GetType();

            //Checking for my custom exception type
            //if (exceptionType is MyCustomException) 
            //{
            //    message = context.Exception.Message;
            //}

            //You can enable logging error
            _logger.LogError(context.Exception.Message);

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new ApiResponse { Message = message, Data = null });
        }
    }

    public class ApiResponse
    {
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
