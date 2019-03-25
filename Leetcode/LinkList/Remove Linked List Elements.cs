using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    public class Remove_Linked_List_Elements
    {
        public static ListNode RemoveElements(ListNode head, int val)
        {
            var demy = new ListNode(0);
            demy.next = head;
            var cur = demy;
            while (cur.next != null)
            {
                if (cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next; //这个应该在 else里面
                }
            }
            return demy.next;
        }
    }
}
