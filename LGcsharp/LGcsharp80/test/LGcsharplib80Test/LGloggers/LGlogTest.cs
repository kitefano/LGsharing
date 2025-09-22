using LGcsharplib80.LGcommons;
using LGcsharplib80.LGloggers;

namespace LGcsharplib80Test.LGloggers
{
    [TestClass]
    public class LGlogTest
    {
        [TestMethod]
        public void LGlog_UseHelper_Kailog()
        {
            // 默认（kailog）
            LGlog.Debug("This is a debug message.");
            LGlog.Info("This is an info message.");
            LGlog.Warn("This is a warning message.");
            LGlog.Error("This is an error message.");
            LGlog.Error("This is an error message with exception.", new Exception("Test Error exception"));
            LGlog.Fatal("This is a fatal message.");
            LGlog.Fatal("This is a  fatal message with exception.", new Exception("Test Fatal exception"));
        }
        [TestMethod]
        public void LGlog_UseHelper_Serilog1()
        {
            string methodName = LGcom.GetCallerMethodName();
            // 第一种方式：使用 Serilog  
            LGlog.Debug($"{methodName}, This is a debug message.", 1);
            LGlog.Info($"{methodName}, This is an info message.", 1);
            LGlog.Warn($"{methodName}, This is a warning message.", 1);
            LGlog.Error($"{methodName}, This is an error message.", null, 1);
            LGlog.Error($"{methodName}, This is an error message with exception.", new Exception("Test Error exception"), 1);
            LGlog.Fatal($"{methodName}, This is a fatal message.", null, 1);
            LGlog.Fatal($"{methodName}, This is a  fatal message with exception.", new Exception("Test Fatal exception"), 1);
        }
        [TestMethod]
        public void LGlog_UseHelper_Serilog2()
        {
            string methodName = LGcom.GetCallerMethodName();
            // 第二种方式：使用 Serilog (推荐)  
            LGslog.Debug($"{methodName}, This is a debug message.");
            LGslog.Info($"{methodName}, This is an info message.");
            LGslog.Warn($"{methodName}, This is a warning message.");
            LGslog.Error($"{methodName}, This is an error message.");
            LGslog.Error($"{methodName}, This is an error message with exception.", new Exception("Test Error exception"));
            LGslog.Fatal($"{methodName}, This is a fatal message.");
            LGslog.Fatal($"{methodName}, This is a  fatal message with exception.", new Exception("Test Fatal exception"));
        }
    }
}
