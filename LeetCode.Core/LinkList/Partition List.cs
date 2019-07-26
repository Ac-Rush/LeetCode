using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Partition_List
    {
        public ListNode Partition(ListNode head, int x)
        {
            var demy = new ListNode(0);
            var demy2 = new ListNode(0);
            var n1 = demy;
            var n2 = demy2;
            while (head != null)
            {
                if (head.val < x)
                {
                    n1.next = head;
                    n1 = n1.next;
                }
                else
                {
                    n2.next = head;
                    n2 = n2.next;
                }
                head = head.next;
            }
            n2.next = null;          //important! avoid cycle in linked list. otherwise u will get TLE.
            n1.next = demy2.next;
            return demy.next;
        }
    }
}
