using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    public class Insertion_Sort_List
    {
        public static ListNode InsertionSortList(ListNode head)
        {
            var dummy = new ListNode(-1);
            while (head != null)
            {
                var cur = dummy;
                while (cur.next != null && cur.next.val < head.val)
                {
                    cur = cur.next;
                }
                var next = cur.next;  //这些跳转要弄清
                cur.next = head;
                head = head.next;
                cur.next.next = next;
            }
            return dummy.next;
        }
    }
}
