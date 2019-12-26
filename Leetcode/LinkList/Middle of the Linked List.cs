using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Middle_of_the_Linked_List
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

            }
            return slow;
        }
    }
}
