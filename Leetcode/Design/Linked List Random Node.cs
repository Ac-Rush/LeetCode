using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.Design
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
    public class Solution
    {
        ListNode head;
        Random random;
        /** @param head The linked list's head.
            Note that the head is guaranteed to be not null, so it contains at least one node. */
        public Solution(ListNode h)
        {
            head = h;
            random = new Random();
        }

        /** Returns a random node's value. */
        public int GetRandom()
        {
            ListNode c = head;
            int r = c.val;
            for (int i = 1; c.next != null; i++)
            {

                c = c.next;
                if (random.Next(i + 1) == i) r = c.val;
            }

            return r;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(head);
     * int param_1 = obj.GetRandom();
     */
}
