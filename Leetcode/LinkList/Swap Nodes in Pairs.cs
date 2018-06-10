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
    }
}
