using LGcsharplib80.LGcommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80Test.LGcommons
{
    [TestClass]
    public class LGcomTest
    {
        [TestMethod]
        public void GetCallerInfo_Helper()
        {
            Console.WriteLine(LGcom.GetCallerInfo());
        }

        // 获取常用系统路径
        [TestMethod]
        public void GetSystemPaths_Helper()
        {
            Console.WriteLine("临时目录: " + LGcom.GetTempPath());
            Console.WriteLine("桌面: " + LGcom.GetDesktopPath());
            Console.WriteLine("我的文档: " + LGcom.GetDocumentsPath());
            Console.WriteLine("程序数据: " + LGcom.GetProgramDataPath());
            Console.WriteLine("AppData Roaming: " + LGcom.GetAppDataRoamingPath());
            Console.WriteLine("AppData Local: " + LGcom.GetAppDataLocalPath());
            Console.WriteLine("用户目录: " + LGcom.GetUserProfilePath());
            Console.WriteLine("Program Files: " + LGcom.GetProgramFilesPath());
            Console.WriteLine("Program Files (x86): " + LGcom.GetProgramFilesX86Path());
            Console.WriteLine("Windows 目录: " + LGcom.GetWindowsPath());
        }

        // 获取当前可执行文件运行路径
        [TestMethod]
        public void GetCurExePaths_Helper()
        {
            Console.WriteLine($"通用方法-获取可执行文件运行路径: {LGcom.GetRunPath(false)}");
            Console.WriteLine($"通用方法-获取可执行文件运行路径: {LGcom.GetRunPath(true)}");
            Console.WriteLine($"获取当前可执行文件的完整路径 (包含 exe 文件名): {LGcom.GetExeFullPath()}");
            Console.WriteLine($"获取当前可执行文件所在的目录 (不包含文件名): {LGcom.GetExeDirectory()}");
            Console.WriteLine($"获取入口程序集（通常是 EXE）的完整路径, 在大多数情况下等价于 GetExeFullPath(): {LGcom.GetAssemblyLocation()}");
            Console.WriteLine($"获取入口程序集所在目录: {LGcom.GetAssemblyDirectory()}");
        }
    }
}
