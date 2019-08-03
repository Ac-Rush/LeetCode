using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class s
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            return toBST(head, null);
        }
        public TreeNode toBST(ListNode head, ListNode tail)
        {
            
            if (head == tail) return null;
            var middle = FindMiddle(head, tail);
            TreeNode thead = new TreeNode(middle.val);
            thead.left = toBST(head, middle);
            thead.right = toBST(middle.next, tail);
            return thead;
        }

        private static ListNode FindMiddle(ListNode head, ListNode tail)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != tail && fast.next != tail)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
