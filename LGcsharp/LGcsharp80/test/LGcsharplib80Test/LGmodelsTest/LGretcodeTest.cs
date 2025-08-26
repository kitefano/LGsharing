using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80Test.LGmodelsTest
{
    [TestClass]
    public class LGretcodeTest
    {
        [TestMethod]
        public void LGretcode_Helper()
        {
            // 输出所有枚举值及其对应的整数值
            foreach (var code in Enum.GetValues(typeof(LGcsharplib80.LGmodels.LGretcode)))
            {
                Console.WriteLine($"错误码：{(int)code}，描述：{code}");
            }
            // 输出LGretcode 枚举的默认值
            var defaultValue = default(LGcsharplib80.LGmodels.LGretcode);
            Console.WriteLine($"LGretcode 枚举的默认值是：{(int)defaultValue}，描述：{defaultValue}");
        }
    }
}
