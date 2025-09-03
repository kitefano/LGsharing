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
        public void LGlog_UseHelper_Serilog()
        {
            // 第一种方式：使用 Serilog
            LGlog.Debug("This is a debug message.", 1);
            LGlog.Info("This is an info message.", 1);
            LGlog.Warn("This is a warning message.", 1);
            LGlog.Error("This is an error message.", null, 1);
            LGlog.Error("This is an error message with exception.", new Exception("Test Error exception"), 1);
            LGlog.Fatal("This is a fatal message.", null, 1);
            LGlog.Fatal("This is a  fatal message with exception.", new Exception("Test Fatal exception"), 1);
            // 第一种方式：使用 Serilog (建议使用这一种) 
            LGslog.Debug("This is a debug message.");
            LGslog.Info("This is an info message.");
            LGslog.Warn("This is a warning message.");
            LGslog.Error("This is an error message.");
            LGslog.Error("This is an error message with exception.", new Exception("Test Error exception"));
            LGslog.Fatal("This is a fatal message.");
            LGslog.Fatal("This is a  fatal message with exception.", new Exception("Test Fatal exception"));
        }
    }
}
