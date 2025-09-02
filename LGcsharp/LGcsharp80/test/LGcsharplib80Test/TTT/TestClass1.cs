using LGcsharplib80;
using LGcsharplib80.LGcommons;

namespace LGcsharplib80Test.Tests
{
    [TestClass]
    public class TestClass1
    {
        [TestMethod]
        public void func()
        {
            LGsharplib80Class1.funcTest($"{LGcom.GetCallerInfo()}: a={0}, b={1}", 10, "20");
            // LGsharplib80Class1.logTest();
        }
    }
}
