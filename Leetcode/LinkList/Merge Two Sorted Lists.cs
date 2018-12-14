using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Merge_Two_Sorted_Lists
    {
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
}
