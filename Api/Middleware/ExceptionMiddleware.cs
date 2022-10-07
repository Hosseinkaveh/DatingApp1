using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Errors;

namespace Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _Logger;
        private readonly IHostEnvironment _env;
          public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> Logger,IHostEnvironment env)
        {
            _next = next;
            _Logger = Logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex,ex.Message);
                context.Request.ContentType ="application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                ? new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                : new ApiException(context.Response.StatusCode,"Internal Server Error");

                var option = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response,option);
                await context.Response.WriteAsync(json);
               
            }
        }
    }
}