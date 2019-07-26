using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Plus_One_Linked_List
    {
        /*
         * 
         
            At the first glance, I want to reverse the inputs, add one, then reverse back. But that is too intuitive and I don't think this is an expected solution. Then what kind of alg would adding one in reverse way for list?

Recursion! With recursion, we can visit list in reverse way! So here is my recursive solution.
    */
        public ListNode PlusOne(ListNode head)
        {
            if (DFS(head) == 0)
            {
                return head;
            }
            else
            {
                ListNode newHead = new ListNode(1);
                newHead.next = head;
                return newHead;
            }

        }
        public int DFS(ListNode head)
        {
            if (head == null) return 1;

            int carry = DFS(head.next);

            if (carry == 0) return 0;

            int val = head.val + 1;
            head.val = val % 10;
            return val / 10;
        }
    }
}
