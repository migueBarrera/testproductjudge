using System;
using Microsoft.Extensions.Logging;

namespace TestApi;

public static class LoggerHelper
{
    public static ILogger<T> CreateLogger<T>()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        return loggerFactory.CreateLogger<T>();
    }
}
