using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.经典代码
{
    class Reverse_Linked_List
    {
        public ListNode ReverseList(ListNode head)
        {
            List<string> strings = null;
            strings.Contains()
            var result = strings.OrderByDescending(str => str).ThenBy(str => str).ToList();
            var count = result.Count;
            var ret= count >= 3 ? result.Take(3).ToList() : result;
            ListNode prev = null;
            while (head != null)
            {
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }
}
