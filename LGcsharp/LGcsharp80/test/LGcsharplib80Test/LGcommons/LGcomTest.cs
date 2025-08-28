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
            Console.WriteLine($"调用者文件名: {LGcom.GetCallerFileName()}");
            Console.WriteLine($"调用者方法名: {LGcom.GetCallerMethodName()}");
            Console.WriteLine($"调用者行号: {LGcom.GetCallerLineNumber()}");
            Console.WriteLine($"调用者类名: {LGcom.GetCallerClassName()}");
            Console.WriteLine($"综合输出-获取调用位置的信息: {LGcom.GetCallerInfo()}");
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
    }
}
