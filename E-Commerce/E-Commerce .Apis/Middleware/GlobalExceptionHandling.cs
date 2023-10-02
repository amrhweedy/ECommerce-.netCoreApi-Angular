using E_Commerce.BL.CusotmException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace E_Commerce_.Apis.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandling : ActionFilterAttribute
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
               await _next(httpContext);

            }
            catch (MyException ex)
            {
                if(ex.InnerException is not null)
                {
                    httpContext.Response.StatusCode = 500;
                   await httpContext.Response.WriteAsJsonAsync(ex.InnerException.Message);
                }
                else
                {
                    httpContext.Response.StatusCode = ex.statusCode;
                    await httpContext.Response.WriteAsJsonAsync(ex.Message);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandling>();
        }
    }
}