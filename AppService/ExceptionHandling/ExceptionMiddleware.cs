using Consulting.Common.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Consulting.Common.Constants;
using Consulting.Domains.MongoDb;
using Consulting.Domains.MongoDb.Service;

namespace Consulting.Applications.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ExceptionLogService exceptionLogService;
        public ExceptionMiddleware(RequestDelegate next, ExceptionLogService _exceptionLogService)
        {
            _next = next;
            exceptionLogService = _exceptionLogService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            //context.Request.Path;
            ExceptionLog exceptionLog = new ExceptionLog()
            {
                date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                exception = exception,
                message = exception.Message,
                ipAddress = context.Connection.RemoteIpAddress.ToString()
            };

#if !DEBUG
            exceptionLogService.AddExceptionLog(exceptionLog);
#endif

            resultObject resultObject = new resultObject();
            var splitPathInfo = context.Request.Path.Value.Split("/");
            resultObject.serverErrors.Add(new ServerError() { hint = exception.Message, type = ConstErrorTypes.ServerError ,
                controllerName = splitPathInfo[2], stackTrace = exception.StackTrace});

            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(resultObject));
        }

        //public Exception GetInnerException(Exception exception)
        //{
        //    if (exception.InnerException != null)
        //    {
        //        exception = exception.InnerException;
        //        GetInnerException(exception);
        //    }

        //    return exception; 
        //}

    }
}
