using System.Runtime.CompilerServices;
using LGcsharplib80.LGcommons;

namespace LGcsharplib80.LGloggers
{
    public static class LGslog
    {
        private static ILGlogger _loggerKailog;
        private static ILGlogger _loggerSerilog;
        // 默认使用Serilog
        static LGslog()
        {
            _loggerKailog = new LGkailog();
            _loggerSerilog = new LGserilog();
        }
        public static void Debug(string message, int logType = 1,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            switch(logType)
            {
                case 0:
                    _loggerKailog?.Debug($"{stret}：{message}");
                    break;
                case 1:
                    _loggerSerilog?.Debug($"{stret}：{message}");
                    break;
                default:
                    _loggerKailog?.Debug($"{stret}：{message}");
                    break;
            }
        }
        public static void Info(string message, int logType = 1,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            switch (logType)
            {
                case 0:
                    _loggerKailog?.Info($"{stret}：{message}");
                    break;
                case 1:
                    _loggerSerilog?.Info($"{stret}：{message}");
                    break;
                default:
                    _loggerKailog?.Info($"{stret}：{message}");
                    break;
            }
        }
        public static void Warn(string message, int logType = 1,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            switch (logType)
            {
                case 0:
                    _loggerKailog?.Warn($"{stret}：{message}");
                    break;
                case 1:
                    _loggerSerilog?.Warn($"{stret}：{message}");
                    break;
                default:
                    _loggerKailog?.Warn($"{stret}：{message}");
                    break;
            }
        }
        public static void Error(string message, Exception? ex = null, int logType = 1,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            switch (logType)
            {
                case 0:
                    _loggerKailog?.Error($"{stret}：{message}", ex);
                    break;
                case 1:
                    _loggerSerilog?.Error($"{stret}：{message}", ex);
                    break;
                default:
                    _loggerKailog?.Error($"{stret}：{message}", ex);
                    break;
            }
        }
        public static void Fatal(string message, Exception? ex = null, int logType = 1,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            switch(logType)
            {
                case 0:
                    _loggerKailog?.Fatal($"{stret}：{message}", ex);
                    break;
                case 1:
                    _loggerSerilog?.Fatal($"{stret}：{message}", ex);
                    break;
                default:
                    _loggerKailog?.Fatal($"{stret}：{message}", ex);
                    break;
            }
        }
    }
}