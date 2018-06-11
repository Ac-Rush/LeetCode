using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Rotate_List
    {
        public static int GetLen(ListNode head)
        {
            var len = 0;
            while (head != null)
            {
                head = head.next;
                len++;
            }
            return len;
        }

        public static ListNode GetLastKth(ListNode head, int k)
        {
            var fast = head;
            var slow = head;
            for (int i = 0; i < k; i++)
            {
                fast = fast.next;
            }
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode fast = dummy, slow = dummy;

            int i;
            for (i = 0; fast.next != null; i++)//Get the total length 
                fast = fast.next;

            for (int j = i - k % i; j > 0; j--) //Get the i-n%i th node
                slow = slow.next;

            fast.next = dummy.next; //Do the rotation
            dummy.next = slow.next;
            slow.next = null;

            return dummy.next;
        }
    }
}
