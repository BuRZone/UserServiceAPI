using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace UserServiceAPI.BLL.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogInfoWithMethodName<T>(this ILogger<T> logger, string message, [CallerMemberName] string caller="")
        {
            logger.LogInformation($"[{typeof(T).Name}.{caller}] " + DateTime.Now.ToString() + " " + message);

        }
    }
}
