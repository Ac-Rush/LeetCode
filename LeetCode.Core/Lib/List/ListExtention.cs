using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.LinkList;

namespace LeetCode.Core.Lib.List
{
    class ListExtention
    {
        private ListNode Reverse(ListNode n)
        {
            ListNode prev = null;
            ListNode cur = n;
            while (cur != null)
            {
                ListNode tmp = cur.next;
                cur.next = prev;
                prev = cur;
                cur = tmp;
            }
            return prev;
        }

        private static ListNode FindMiddle(ListNode head)
        {
            //var fast = head.next;  //多走一步，后来证明没有必要
            var fast = head;
            var slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        private static ListNode FindMiddlePrev(ListNode head)
        {
            ListNode prev = head;
            var fast = head;
            var slow = head;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                fast = fast.next.next;
                slow = slow.next;
            }
            return prev;
        }
    }
}
