using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.Sort
{
    public class Sort_List
    {
        public static ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var middle = FindMiddle(head);
            var rigth = SortList(middle.next);
            middle.next = null;
            var left = SortList(head);
            return Merge(left, rigth);
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

        private static ListNode Merge(ListNode l1, ListNode l2)
        {

            ListNode l = new ListNode(0), p = l;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    p.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    p.next = l2;
                    l2 = l2.next;
                }
                p = p.next;
            }

            if (l1 != null)
                p.next = l1;

            if (l2 != null)
                p.next = l2;

            return l.next;
        }


        private ListNode Merge2(ListNode left, ListNode right)
        {

            var dummy = new ListNode(0);
            var tail = dummy;
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    tail.next = left;
                    left = left.next;
                }
                else
                {
                    tail.next = right;
                    right = right.next;
                }
                tail = tail.next; // my bug 没有移动 tail
            }
            if (right != null)
            {
                tail.next = right;
            }
            else if (left != null)
            {
                tail.next = left;
            }
            return dummy.next;
        }


    }
}
