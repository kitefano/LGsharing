using Serilog;
using Serilog.Events;

namespace LGcsharplib80.LGloggers
{
    public class LGserilog : ILGlogger
    {
        private readonly Serilog.ILogger _logger;
        public LGserilog(string logFilePath = "logs/.log")
        {
            _logger = new LoggerConfiguration()
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
                .WriteTo.Seq("http://116.62.145.219:5341") // 如果没有运行Seq，可以注释掉这一行
                .CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (_, __) => Log.CloseAndFlush();
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
