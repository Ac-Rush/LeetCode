using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
    class Linked_List_Components
    {
        public int NumComponents(ListNode head, int[] G)
        {
            var set = new HashSet<int>();
            foreach (var n in G)
            {
                set.Add(n);
            }

            var ans = 0;
            while (head != null)
            {
                if (set.Contains(head.val) &&
                        (head.next == null || !set.Contains(head.next.val)))
                    ans++;
                head = head.next;
            }
            return ans;
        }
    }
}
