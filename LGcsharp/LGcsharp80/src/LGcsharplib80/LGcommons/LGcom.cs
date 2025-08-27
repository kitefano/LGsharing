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
        // 综合输出-获取调用位置的信息（文件名、类名、方法名、行号）
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

        #region 获取当前程序的信息
        // 获取程序集信息, isEntryAssembly 为 true 时获取入口程序集（通常是主程序 exe）, 为 false 时获取当前类所在程序集的名字
        // GetExecutingAssembly()代码在动态加载的程序集中执行，该方法可能抛出异常, 此时使用 Assembly.GetCallingAssembly()
        public static Assembly GetCurrentAssembly(bool isEntryAssembly = true)
        {
            try
            {
                return isEntryAssembly 
                    ? Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()
                    : Assembly.GetExecutingAssembly();
            }
            catch (Exception)
            {
                return Assembly.GetCallingAssembly();
            }
                
        }
        // 获取当前程序集的名称
        // 返回值：程序集的名称（不带扩展名）。例如：程序集文件是 MyApp.dll 或 MyApp.exe，返回 "MyApp"。
        public static string GetCurrentAssemblyName()
        {
            return GetCurrentAssembly().GetName().Name ?? string.Empty;
        }
        // 获取当前应用程序的名称
        // 返回值：当前应用程序域的“友好名称”。通常就是 启动的文件名，带扩展名。例如：启动的是 MyApp.exe，返回 "MyApp.exe"。
        // 特殊情况：如果是在单元测试、IIS 或某些托管环境下，FriendlyName 可能会是 vstest.executionengine.x86.exe 或 w3wp.exe，而不是你预期的程序集名。
        public static string GetAppName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }
        // 获取当前应用程序的目录
        // 返回值：当前应用程序域的 BaseDirectory。这通常是应用程序的启动目录。
        // 特殊情况：如果是在 IIS 下运行，BaseDirectory 可能会是 IIS 的应用程序池目录，而不是你预期的应用程序目录。
        // 建议：如果需要获取应用程序的实际目录，建议使用 GetExeDirectory() 或 GetAssemblyDirectory()。
        public static string GetAppPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        // 获取程序集版本
        // 返回值：程序集的版本信息。例如：1.0.0.0。
        public static Version GetAssemblyVersion()
        {
            return GetCurrentAssembly().GetName().Version ?? new Version(0, 0, 0, 0);
        }
        // 获取程序集文件版本和程序集版本
        // 文件版本：通过 [AssemblyFileVersion] 特性设置，通常用于显示给用户看的版本号，可以包含更多细节（例如 1.0.0.1234）。
        // 文件版本：优点，这是 Windows 资源管理器右键 → 属性 → 详细信息 看到的版本号，适合展示给用户。
        // 程序集版本：通过 [AssemblyVersion] 特性设置，用于 CLR 程序集绑定（程序集加载时版本检查），比较“技术化”。
        // 程序集版本：缺点，用户通常看不到这个版本号，不适合展示给用户。通常不会频繁改动（很多项目 AssemblyVersion 可能一直是 1.0.0.0）。
        // 返回值：程序集的文件版本信息。例如：1.0.0.0。
        public static (string FileVersion, string AssemblyVersion) GetAppVersions()
        {
            var assembly = GetCurrentAssembly();
            string fileVersion = string.Empty;
            string asmVersion = string.Empty;

            try
            {
                fileVersion = FileVersionInfo
                    .GetVersionInfo(assembly.Location)
                    .FileVersion ?? string.Empty;
            }
            catch { }

            try
            {
                asmVersion = assembly
                    .GetName()
                    .Version?
                    .ToString() ?? string.Empty;
            }
            catch { }

            return (fileVersion, asmVersion);
        }
        #endregion
    }
}
