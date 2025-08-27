using LGcsharplib80.LGmodels;
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
            foreach (var code in Enum.GetValues(typeof(LGretcode)))
            {
                Console.WriteLine($"错误码：{(int)code}，描述：{code}");
            }
            // 输出LGretcode 枚举的默认值
            var defaultValue = default(LGretcode);
            Console.WriteLine($"LGretcode 枚举的默认值是：{(int)defaultValue}，描述：{defaultValue}");
            Assert.IsTrue((int)defaultValue == 0);
            Assert.IsTrue(defaultValue == LGretcode.Success);
            // 获取中文描述信息：
            // 获取默认值中文描述信息
            Console.WriteLine($"LGretcode 枚举默认值中文描述信息：{default(LGretcode).GetMessage()}");
            Assert.IsTrue(default(LGretcode).GetMessage() == "操作成功");
            // 获取特定错误码的中文描述信息            
            Console.WriteLine($"HttpNotFound 中文描述信息：{LGretcode.HttpNotFound.GetMessage()}");
            Assert.IsTrue(LGretcode.HttpNotFound.GetMessage() == "资源不存在");
        }
    }
}
