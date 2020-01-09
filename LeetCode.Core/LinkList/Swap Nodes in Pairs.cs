using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Swap_Nodes_in_Pairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head?.next == null)
                return head;
            ListNode n = head.next;
            head.next = SwapPairs(head.next.next);
            n.next = head;
            return n;
        }


        public ListNode SwapPairs2(ListNode head)
        {
            var dummy = new ListNode(0) { next = head };
            var cur = dummy;
            while (cur.next != null && cur.next.next != null)
            {
                ListNode first = cur.next, second = cur.next.next;
                var next = second.next;
                cur.next = second;
                second.next = first;
                first.next = next;
                cur = first;
            }
            return dummy.next;
        }
    }
}
