namespace LGcsharplib80.LGloggers
{
    public class LGkailog : ILGlogger
    {
        private readonly string _logDir;
        private readonly object _lockObj = new object();
        public LGkailog(string logDir = "logs", string sequrl = "http://116.62.145.219:5341")
        {
            _logDir = logDir;
            if (!Directory.Exists(_logDir))
            {
                Directory.CreateDirectory(_logDir);
            }
        }
        private void WriteLog(string level, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            string logEntry = $"[{timestamp}] [{level}] {message}{Environment.NewLine}";
            // 控制台输出
            Console.Write(logEntry);
            // 文件输出（每天一个文件）
            string logFilePath = Path.Combine(_logDir, $"{DateTime.Now:yyyy-MM-dd}.log");
            lock (_lockObj)
            {
                File.AppendAllText(logFilePath, logEntry);
            }
        }

        public void Debug(string message) => WriteLog("DEBUG", message);
        public void Info(string message) => WriteLog("INFO", message);
        public void Warn(string message) => WriteLog("WARN", message);
        public void Error(string message, Exception? ex = null)
        {
            if (ex != null)
            {
                WriteLog("ERR", $"{message} \nException: {ex}");
            }else
            {
                WriteLog("ERR", message);
            }
        }
        public void Fatal(string message, Exception? ex = null)
        {
            if (ex != null)
            {
                WriteLog("FTL", $"{message} \nException: {ex}");
            }else
            {
                WriteLog("FTL", message);
            }
        }
    }
}
