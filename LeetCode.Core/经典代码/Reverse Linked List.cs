using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.经典代码
{
    class Reverse_Linked_List
    {
        public ListNode ReverseList(ListNode head)
        {
           
            ListNode prev = null;
            while (head != null)
            {
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }

        /// <summary>
        /// 递归版
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode reverseList(ListNode head)
        {
            /* recursive solution */
            return reverseListInt(head, null);
        }
        /// <summary>
        /// new head 就相当于，
        /// new head 是null, 链表1   12345null 变成了 2345null 和 1null
        ///
        /// 1->2->3->4->5->null
        /// 5->4->3->2->1->null
        /// </summary>
        /// <param name="head"></param>
        /// <param name="newHead"></param>
        /// <returns></returns>
        private ListNode reverseListInt(ListNode head, ListNode newHead)
        {
            if (head == null)
                return newHead;
            ListNode next = head.next;
            head.next = newHead;
            return reverseListInt(next, head);
        }

        /// <summary>
        /// 真是不好想
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode reverseList2(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode p = reverseList2(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
    }
}
