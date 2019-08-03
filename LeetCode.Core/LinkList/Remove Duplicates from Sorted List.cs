using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Remove_Duplicates_from_Sorted_List
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;
            var prev = head;
            while (prev.next != null)
            {
                if (prev.val == prev.next.val)
                {
                    prev.next = prev.next.next;
                }
                else
                {
                    prev = prev.next;
                }

            }
            return head;
        }
    }
}
