using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Testing.Platform.Extensions.Messages;

namespace Tiku._1to50
{
    [TestClass]
    public class _2class
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                ListNode l1tmp = l1;
                ListNode l2tmp = l2;
                int flag = 0;
                int quyu = 0;
                int sum = 0;
                while (l1tmp != null || l2tmp != null || quyu != 0)
                {
                    if (l1tmp != null)  // l2==null 或者 l2!=null
                    {
                        if (l2tmp != null) // l2!=null
                        {
                            sum = l1tmp.val + l2tmp.val + quyu;
                            if (sum >= 10)
                            {
                                l1tmp.val = sum - 10;
                                l2tmp.val = sum - 10;
                                quyu = 1;
                            }
                            else
                            {
                                l1tmp.val = sum;
                                l2tmp.val = sum;
                                quyu = 0;
                            }
                        }
                        else // l2==null
                        {
                            flag = 1;
                            sum = l1tmp.val + quyu;
                            if (sum < 10)
                            {
                                l1tmp.val = sum;
                                quyu = 0;
                            }
                            else
                            {
                                l1tmp.val = sum - 10;
                                quyu = 1;
                            }
                        }
                    }
                    else  // 如果l1==null, 那么l2!=null
                    {
                        flag = 2;
                        sum = l2tmp.val + quyu;
                        if (sum < 10)
                        {
                            l2tmp.val = sum;
                            quyu = 0;
                        }
                        else
                        {
                            l2tmp.val = sum - 10;
                            quyu = 1;
                        }
                    }
                    if (flag == 0) // l1,l2 != null
                    { 
                        if (quyu == 1)
                        {
                            if (l1tmp.next == null && l2tmp.next == null)
                            {
                                l1tmp.next = new ListNode();
                            }
                        } 
                        l1tmp = l1tmp.next;
                        l2tmp = l2tmp.next;
                    }else if (flag == 1) // l1 != null, l2 == null
                    {
                        if (quyu == 1)
                        {
                            if (l1tmp.next == null)
                            {
                                l1tmp.next = new ListNode();
                            }
                        }
                        l1tmp = l1tmp.next;
                    }else if (flag == 2) // l1==null, l2!=null
                    {
                        if (quyu == 1)
                        {
                            if (l2tmp.next == null)
                            {
                                l2tmp.next = new ListNode();
                            }
                        }
                        l2tmp = l2tmp.next;
                    }
                }
                if (flag == 0 || flag == 1)
                {
                    return l1;
                }else
                {
                    return l2; 
                }                
            }
        }
        [TestMethod]
        public void _2func()
        {
            // Case1:[2,4,3], [5,6,4], [7,0,8]
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            ListNode ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(7, ret.val);
            Assert.AreEqual(0, ret.next.val);
            Assert.AreEqual(8, ret.next.next.val);
            // Case2:[0], [0], [0]
            l1 = new ListNode(0);
            l2 = new ListNode(0);
            ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(0, ret.val);
            // Case3:[9,9,9,9,9,9,9], [9,9,9,9], [8,9,9,9,0,0,0,1]
            l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(8, ret.val);
            Assert.AreEqual(9, ret.next.val);
            Assert.AreEqual(9, ret.next.next.val);
            Assert.AreEqual(9, ret.next.next.next.val);
            Assert.AreEqual(0, ret.next.next.next.next.val);
            Assert.AreEqual(0, ret.next.next.next.next.next.val);
            Assert.AreEqual(0, ret.next.next.next.next.next.next.val);
            // case4: [0,8,6,5,6,8,3,5,7], [6,7,8,0,8,5,8,9,7]
            l1 = new ListNode(0, new ListNode(8, new ListNode(6, new ListNode(5, new ListNode(6, new ListNode(8, new ListNode(3, new ListNode(5, new ListNode(7)))))))));
            l2 = new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(0, new ListNode(8, new ListNode(5, new ListNode(8, new ListNode(9, new ListNode(7)))))))));
            ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(6, ret.val);
            Assert.AreEqual(5, ret.next.val);
            Assert.AreEqual(5, ret.next.next.val);
            Assert.AreEqual(6, ret.next.next.next.val);
            Assert.AreEqual(4, ret.next.next.next.next.val);
            Assert.AreEqual(4, ret.next.next.next.next.next.val);
            Assert.AreEqual(2, ret.next.next.next.next.next.next.val);
            Assert.AreEqual(5, ret.next.next.next.next.next.next.next.val);
            Assert.AreEqual(5, ret.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(1, ret.next.next.next.next.next.next.next.next.next.val);
            // case5： [3,6,2,1,3,4,9,3,5,1]， [0,6,9,9,1,4,4,0,5]
            l1 = new ListNode(3, new ListNode(6, new ListNode(2, new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(9, new ListNode(3, new ListNode(5, new ListNode(1))))))))));
            l2 = new ListNode(0, new ListNode(6, new ListNode(9, new ListNode(9, new ListNode(1, new ListNode(4, new ListNode(4, new ListNode(0, new ListNode(5)))))))));
            ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(3, ret.val);
            Assert.AreEqual(2, ret.next.val);
            Assert.AreEqual(2, ret.next.next.val);
            Assert.AreEqual(1, ret.next.next.next.val);
            Assert.AreEqual(5, ret.next.next.next.next.val);
            Assert.AreEqual(8, ret.next.next.next.next.next.val);
            Assert.AreEqual(3, ret.next.next.next.next.next.next.val);
            Assert.AreEqual(4, ret.next.next.next.next.next.next.next.val);
            Assert.AreEqual(0, ret.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(2, ret.next.next.next.next.next.next.next.next.next.val);
            // case6: [2,4,9], [5,6,4,9], [7,0,4,0,1]
            l1 = new ListNode(2, new ListNode(4, new ListNode(9)));
            l2 = new ListNode(5,new ListNode(6, new ListNode(4, new ListNode(9))));
            ret = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual(7, ret.val);
            Assert.AreEqual(0, ret.next.val);
            Assert.AreEqual(4, ret.next.next.val);
            Assert.AreEqual(0, ret.next.next.next.val);
            Assert.AreEqual(1, ret.next.next.next.next.val);
        }
    }
}
