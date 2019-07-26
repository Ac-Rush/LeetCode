using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Remove_Nth_Node_From_End_of_List
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode start = new ListNode(0);  // 还是  demy node 好用 
            ListNode slow = start, fast = start;
            slow.next = head;

            //Move fast in front so that the gap between slow and fast becomes n
            //分步来 很清晰， fast 先走n步
            for (int i = 1; i <= n + 1; i++)
            {
                fast = fast.next;
            }
            //Move fast to the end, maintaining the gap
            //然后一起走， 
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            //Skip the desired node
            slow.next = slow.next.next;
            return start.next;
        }
    }
}
