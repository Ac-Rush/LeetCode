using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Palindrome_Linked_List
    {
        /// <summary>
        /// 这个太棒了
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }
            ListNode p1 = head;
            ListNode p2 = head;
            ListNode p3 = p1.next;
            ListNode pre = p1;
            //find mid pointer, and reverse head half part
            //找中点，并reverse 前半部分
            while (p2.next != null && p2.next.next != null)
            {
                p2 = p2.next.next;
                pre = p1;
                p1 = p3;
                p3 = p3.next;
                p1.next = pre;
            }

            //判奇偶，
            //odd number of elements, need left move p1 one step
            if (p2.next == null)
            {
                p1 = p1.next;
            }
            else
            {   //even number of elements, do nothing

            }
            //比较
            //compare from mid to head/tail
            while (p3 != null)
            {
                if (p1.val != p3.val)
                {
                    return false;
                }
                p1 = p1.next;
                p3 = p3.next;
            }
            return true;

        }
    }
}
