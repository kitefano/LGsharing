using LGcsharplib80.LGmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80Test.LGmodelsTest
{
    [TestClass]
    public class LGretcodeHelperTest
    {
        [TestMethod]
        public void GetMessage_Helper()
        {
            var code = default(LGretcode);
            string message = LGretcodeHelper.GetMessage((int)code);
            Console.WriteLine($"错误码：{(int)code}，描述：{message}");
        }
    }
}
