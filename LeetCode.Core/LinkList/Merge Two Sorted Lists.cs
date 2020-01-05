using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Merge_Two_Sorted_Lists
    {
        public ListNode MergeTwoLists0(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var cur = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }
                cur = cur.next;
            }
            cur.next = l1 == null ? l2 : l1;
            return dummy.next;
        }



        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var demy = new ListNode(0);
            var curt = demy;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    curt.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curt.next = l2;
                    l2 = l2.next;
                }
                curt = curt.next; // god , 缺了这一句 大错特错 
            }
            if (l1 != null) curt.next = l1;
            if (l2 != null) curt.next = l2;
            return demy.next;
        }



    }

    class Merge_Two_Sorted_Lists_Recursive
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                var next = l1.next;
                l1.next = MergeTwoLists(next, l2);
                return l1;
            }
            else
            {
                var next = l2.next;
                l2.next = MergeTwoLists(l1, next);
                return l2;
            }
        }
    }
}
