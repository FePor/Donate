using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MyLocalSite
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CSP
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration;
        //private const string HEADER = "Content-Security-Policy";

        public CSP(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            httpContext.Response.Headers.Add(configuration.GetSection("CSP:Header").Value, configuration.GetSection("CSP:Values").Value);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CSPExtensions
    {
        public static IApplicationBuilder UseCSP(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CSP>();
        }
    }
}
