using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGcsharplib80.LGcommons;
using LGcsharplib80.LGloggers;

namespace LGcsharplib80Test.LGloggers
{
    [TestClass]
    public class LGlogTest
    {
        [TestMethod]
        public void LGlog_UseHelper()
        {
            // 默认（Serilog）
            LGlog.Debug("This is a debug message.");
            LGlog.Info("This is an info message.");
            LGlog.Warn("This is a warning message.");
            LGlog.Error("This is an error message.");
            LGlog.Error("This is an error message with exception.", new Exception("Test Error exception"));
            LGlog.Fatal("This is a fatal message.");
            LGlog.Fatal("This is a  fatal message with exception.", new Exception("Test Fatal exception"));
            Console.WriteLine($"{LGcom.GetCallerInfo()}");
        }
    }
}
