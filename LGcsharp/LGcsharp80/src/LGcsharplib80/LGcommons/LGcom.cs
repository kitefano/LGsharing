using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80.LGcommons
{
    public class LGcom
    {
        #region 获取文件名、类名、函数名、行号。
        // 获取调用者的文件名（不含路径） 
        public static string GetCallerFileName([CallerFilePath] string filePath = "")
        {
            return System.IO.Path.GetFileName(filePath);
        }
        // 获取调用的方法名
        public static string GetCallerMethodName([CallerMemberName] string memberName = "")
        {
            return memberName;
        }
        // 获取调用的行号
        public static int GetCallerLineNumber([CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }
        // 获取调用的类名（通过堆栈）
        public static string GetCallerClassName()
        {
            string className = "UnknownClass";
            var stackTrace = new StackTrace();

            if (stackTrace.FrameCount > 1)
            {
                var method = stackTrace?.GetFrame(1)?.GetMethod();
                className = method?.DeclaringType?.FullName ?? "UnknownClass";
            }

            return className;
        }
        // 综合输出:获取调用位置的信息（文件名、类名、方法名、行号）
        public static string GetCallerInfo(
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string fileName = GetCallerFileName(filePath);
            string className = GetCallerClassName();
            return $"{className}.{memberName}() @ {fileName}[{lineNumber}]";
        }
        #endregion

        #region 获取常用系统路径
        // 获取 Windows 临时文件夹路径 (例如 C:\Users\xxx\AppData\Local\Temp)
        public static string GetTempPath()
        {
            return Path.GetTempPath();
        }
        // 获取桌面路径
        public static string GetDesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        // 获取“我的文档”路径
        public static string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        // 获取“程序数据”路径 (所有用户共享的 AppData\Roaming 或 ProgramData)
        public static string GetProgramDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        }
        // 获取当前用户 AppData\Roaming 路径
        public static string GetAppDataRoamingPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        // 获取当前用户 AppData\Local 路径
        public static string GetAppDataLocalPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
        // 获取当前用户主目录 (例如 C:\Users\xxx)
        public static string GetUserProfilePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
        // 获取“程序文件夹”路径 (C:\Program Files)
        public static string GetProgramFilesPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }
        // 获取“程序文件夹(x86)”路径 (C:\Program Files (x86))
        public static string GetProgramFilesX86Path()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        }
        // 获取系统 Windows 目录 (C:\Windows)
        public static string GetWindowsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        }
        #endregion

        #region 获取当前可执行文件运行路径
        // 通用方法-获取可执行文件运行路径。 true 返回带 exe 文件名的完整路径；false 返回所在目录
        public static string GetRunPath(bool includeFileName = false)
        {
            // 入口程序集（通常是 exe 程序）
            string exePath = Assembly.GetEntryAssembly()?.Location
                             ?? Process.GetCurrentProcess().MainModule?.FileName
                             ?? string.Empty;

            if (includeFileName)
            {
                return exePath; // 带 exe 文件名
            }
            else
            {
                return Path.GetDirectoryName(exePath) ?? string.Empty; // 只返回目录
            }
        }
        // 获取当前可执行文件的完整路径 (包含 exe 文件名)
        public static string GetExeFullPath()
        {
            return Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
        }
        // 获取当前可执行文件所在的目录 (不包含文件名)
        public static string GetExeDirectory()
        {
            return Path.GetDirectoryName(GetExeFullPath()) ?? string.Empty;
        }
        // 获取入口程序集（通常是 EXE）的完整路径, 在大多数情况下等价于 GetExeFullPath()
        public static string GetAssemblyLocation()
        {
            return Assembly.GetEntryAssembly()?.Location ?? string.Empty;
        }
        // 获取入口程序集所在目录
        public static string GetAssemblyDirectory()
        {
            return Path.GetDirectoryName(GetAssemblyLocation()) ?? string.Empty;
        }
        #endregion
    }
}
