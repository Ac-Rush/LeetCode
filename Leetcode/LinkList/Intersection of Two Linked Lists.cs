using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Intersection_of_Two_Linked_Lists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            //boundary check
            if (headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;

            //if a & b have different len, then we will stop the loop after second iteration
            //两遍走到头肯定退出
            while (a != b)
            {
                //这太厉害了，两个指针 两个链表都走一遍 那么就相遇到一个点
                //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }
    }
}
