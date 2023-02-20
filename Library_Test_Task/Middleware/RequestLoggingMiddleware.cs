﻿namespace Library_Test_Task.Middleware;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        finally
        {
            _logger.LogInformation(
                "Request:\n\tMethod:{method}\n\tHeaders: {headers}\n\tBody: {body}\n\tUrl: {url} =>Response Code: {statusCode}",
                context.Request?.Method,
                context.Request?.Headers,
                 context.Request.BodyReader.ToString(),
                context.Request?.Path.Value,
                context.Response?.StatusCode);
        }
    }
}
