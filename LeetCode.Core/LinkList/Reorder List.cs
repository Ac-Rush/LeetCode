using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Reorder_List
    {
        

        public void ReorderList2(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            //Find the middle of the list // 找中间
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //Reverse the half after middle  1->2->3->4->5->6 to 1->2->3->6->5->4
            // Reverse the second half
            ListNode head2 = reverse(slow.next);
            slow.next = null;

            // Link the two halves together
            while (head != null && head2 != null)
            {
                ListNode tmp1 = head.next;
                ListNode tmp2 = head2.next;
                head2.next = head.next;
                head.next = head2;
                head = tmp1;
                head2 = tmp2;
            }
        }

        private ListNode reverse(ListNode n)
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




        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            //Find the middle of the list // 找中间
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //Reverse the half after middle  1->2->3->4->5->6 to 1->2->3->6->5->4
            ListNode preMiddle = slow;
            ListNode preCurrent = slow.next;
            while (preCurrent.next != null) //翻转后半段
            {
                ListNode current = preCurrent.next;
                preCurrent.next = current.next;
                current.next = preMiddle.next;
                preMiddle.next = current;
            }

            //Start reorder one by one  1->2->3->6->5->4 to 1->6->2->5->3->4
            slow = head;
            fast = preMiddle.next;
            while (slow != preMiddle) // 合并
            {
                preMiddle.next = fast.next;
                fast.next = slow.next;
                slow.next = fast;
                slow = fast.next;
                fast = preMiddle.next;
            }
        }
    }
}
