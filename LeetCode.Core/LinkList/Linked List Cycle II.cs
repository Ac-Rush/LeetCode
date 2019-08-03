using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Linked_List_Cycle_II
    {
        public ListNode DetectCycle(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast) break;
            }
            if (fast == null || fast.next == null) return null; // 这就是上面 while的 推出条件
            fast = head;
            while (fast != slow)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return slow;
        }
    }
}
