using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Add_Two_Numbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var demy = new ListNode(0);
            var cur = demy;
            var carry = 0;

            while (l1 != null || l2 != null)
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                carry = sum / 10;
                var newNode = new ListNode(sum % 10);
                cur.next = newNode;
                cur = newNode;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (carry == 1)
            {
                var newNode = new ListNode(1);
                cur.next = newNode;
            }

            return demy.next;
        }
    }
}
