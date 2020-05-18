using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.HandleRequest
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private IServiceCollection _services;
        public IConfiguration _configuration { get; }

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
          //  _services = serviceCollection ;
          //  _configuration = configuration;
        }

        public Task Invoke(HttpContext httpContext , IServiceProvider provider)
        {                   
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }


}
