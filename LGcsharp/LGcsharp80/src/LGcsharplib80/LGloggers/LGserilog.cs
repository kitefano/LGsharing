using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace LGcsharplib80.LGloggers
{
    public class LGserilog : ILGlogger
    {
        private readonly Serilog.ILogger _logger;
        public LGserilog(string logDir = "logs", string sequrl = "http://116.62.145.219:5341")
        {
            string logFilePath = Path.Combine(logDir, ".log");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .WriteTo.File(logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                //.WriteTo.Seq("http://116.62.145.219:5341") // 同步发送，如果没有运行Seq，可以注释掉这一行
                .WriteTo.Async(a => a.Seq(
                    $"{sequrl}",
                    batchPostingLimit: 1000,  // 单批次最多多少条  
                    period: TimeSpan.FromSeconds(5)  // 每隔多久推送一次  
                )) // ✅ 异步发送
                .CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (_, __) => Log.CloseAndFlush();
            _logger = Log.Logger;
        }
        public void Debug(string message) => _logger.Debug(message);

        public void Info(string message) => _logger.Information(message);

        public void Warn(string message) => _logger.Warning(message);

        public void Error(string message, Exception? ex = null)
        {
            if (ex != null)
            {
                _logger.Error(ex, message);
            }
            else
            {
                _logger.Error(message);
            }
        }

        public void Fatal(string message, Exception? ex = null)
        {
            if (ex != null)
            {
                _logger.Fatal(ex, message);
            }
            else
            {
                _logger.Fatal(message);
            }
        }
    }
}
