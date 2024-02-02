using Newtonsoft.Json;
using System.Net;

namespace Sela.Task.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        //private readonly ILogger<ExceptionHandlerMiddleware> logger;


        //public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        //{
        //    this.logger = logger;
        //}


        public async System.Threading.Tasks.Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // Log This Exception
                //logger.LogError(ex, $"{errorId} : {ex.Message}");

                // Return A Custom Exrror Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! Please contact admin."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
