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
            ListNode dummy = new ListNode(0);  // 还是  demy node 好用 \
            dummy.next = head;
            ListNode slow = dummy, fast = dummy;  // slow 和 fast 必须从dummy 开始，因为可能删除的是head

            //Move fast in front so that the gap between slow and fast becomes n
            //分步来 很清晰， fast 先走n +1步
            while (n-- >= 0)
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
            return dummy.next;
        }
    }
}
