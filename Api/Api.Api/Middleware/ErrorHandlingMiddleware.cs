using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // public async Task Invoke(HttpContext context)
        // {
        //     try
        //     {
        //         await _next(context);
        //     }
        //     catch(Exception ex)
        //     {
        //         //await HandleExceptionAsync(context, ex);
        //     }
        // }

        // private Task HandleExceptionAsync(HttpContext context, Exception ex)
        // {
        //     var code = HttpStatusCode.InternalServerError;
        // }
    }
}