using System.Diagnostics;
using LGcsharplib80.LGcommons;
using Microsoft.Extensions.Logging;

namespace LGcsharplib80
{
    public class LGsharplib80Class1
    {
        public static void funcTest(string fmt, params object[] args)
        {
            Console.WriteLine(fmt);
            Console.WriteLine(args);
            Console.WriteLine(fmt, args);
        }

        private static ILogger _logger;
        public static void logPrintToConsoleTest()
        {
            string str = string.Empty;
            // 创建日志工厂并配置
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole() // 输出到控制台
                    .SetMinimumLevel(LogLevel.Trace); // 设置最低日志级别
            });
            string categoryName = "LGmelog";
            _logger = loggerFactory.CreateLogger(categoryName);
            _logger.LogTrace(str = $"{LGcom.GetCallerInfo()}, 这是一个Trace");
        }
        public static void logPrintToFileTest()
        {

        }
    }
}
