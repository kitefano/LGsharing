using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LGcsharplib80.LGcommons;

namespace LGcsharplib80.LGloggers
{
    public static class LGlog
    {
        private static ILGlogger _logger;
        public static void UseLogger(ILGlogger logger)
        {
            _logger = logger;
        }
        // 默认使用Serilog
        static LGlog()
        {
            _logger = new LGserilog();
        }
        public static void Debug(string message,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            _logger?.Debug($"{stret}：{message}");
        }

        public static void Info(string message,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = LGcom.GetCallerFileName(filePath);
            string className = LGcom.GetCallerClassName();
            string stret = $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
            _logger?.Info($"{stret}：{message}");
        }
        public static void Warn(string message,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0) => _logger?.Warn($"{stret}：{message}");
        public static void Error(string message, Exception? ex = null,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0) => _logger?.Error($"{stret}：{message}", ex);
        public static void Fatal(string message, Exception? ex = null,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0) => _logger?.Fatal($"{stret}：{message}", ex);
    }
}