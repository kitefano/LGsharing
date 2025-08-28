using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGcsharplib80.LGcommons;

namespace LGcsharplib80Test.Tests
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void func()
        {
            //// 写入调试信息，仅在调试版本中有效
            //Debug.WriteLine("This is a Debug message.");

            //// 写入跟踪信息，调试和发布版本都有效
            //Trace.WriteLine("This is a Trace message.");

            //// 使用 Trace.WriteLine 写入日志到控制台或文件
            //Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            //Trace.WriteLine("This log will be written to the file.");

            //// 调试断言：如果条件为false，则会抛出异常
            //Debug.Assert(1 + 1 == 3, "Math error!");
            Console.WriteLine($"{LGcom.GetCallerInfo()}");
        }
    }
}
