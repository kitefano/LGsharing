using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tiku._1to50
{
    [TestClass]
    public class _3class
    {
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                // 参数检查
                // 0 <= s.length <= 5 * 10000
                if (s.Length < 0 || s.Length > 5 * Math.Pow(10, 4))
                {
                    return -1;
                }
                // s 由英文字母、数字、符号和空格组成
                // 其实题目提交的时候有一个歧义： s是否是空串"" 测试都能通过。             
                foreach (char c in s)
                {
                    // 内容检查：必须是可打印 ASCII (0x20–0x7E)，即空格到波浪线
                    if (c < 0x20 || c > 0x7E)
                    {
                        return -1;
                    }
                }
                // code 
                List<char> list = new List<char>();
                List<char> retlist = new List<char>();
                int count = 0;
                int maxCount = 0;
                foreach (char ch in s)
                {
                    list.Add(ch);
                }
                for (int i = 0; i < list.Count; i++)
                {

                }

                return 1;
            }
        }
        [TestMethod]
        public void _3func()
        {
            string s = string.Empty;
            int ret = 0;
            // seccuss
            // case1: "abcabcbb", 3
            s = "abcabcbb";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case1: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(3, ret);

            // case2: "bbbbb", 1
            s = "bbbbb";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case2: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(1, ret);

            // case3: "pwwkew", 3
            s = "pwwkew";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case3: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(3, ret);

            // case4: "  ", 1
            s = "  ";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case4: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(1, ret);

            // case5: "a  _5,.?!@", 8
            s = "a  _5,.?!@";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case5: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(8, ret);

            // case6: "a5###$$$a5%===%%^|===||&===&&+===++-===--*===**/===/a5===<===>===", 5
            s = "a5###$$$a5%===%%^|===||&===&&+===++-===--*===**/===/a5===<===>===";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case6: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(5, ret);

            // case7: "a5\\\"\\ ", 4
            s = "a5\\\"\\ ";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case7: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(4, ret);

            // case8: "" , 0
            s = "";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case8: ret = {ret}");
            Assert.AreNotEqual(-1, ret);
            Assert.AreEqual(0, ret);

            // fail
            // case21: "a5\n"
            s = "a5\n";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case21: ret = {ret}");
            Assert.AreEqual(-1, ret);

            // case22: "a5\t"
            s = "a5\t";
            ret = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine($"Case22: ret = {ret}");
            Assert.AreEqual(-1, ret);
        }
    }
}
