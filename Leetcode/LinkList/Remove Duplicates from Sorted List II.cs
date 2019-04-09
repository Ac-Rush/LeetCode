using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Remove_Duplicates_from_Sorted_List_II
    {
        /// <summary>
        /// my solution 一次过
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
           // if (head == null) return head;
            var dummyHead = new ListNode(0);
            dummyHead.next = head;
            var prev = dummyHead;
            while (head != null && head.next !=null)
            {
                if (head.val != head.next.val)
                {
                    prev = head;
                    head = head.next;
                }
                else
                {
                    var value = head.val;
                    while (head != null && head.val == value)
                    {
                        head = head.next;
                    }
                    prev.next = head;
                }
            }
            return dummyHead.next;
        }
    }
}
