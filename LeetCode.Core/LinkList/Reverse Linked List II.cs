using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{

    class Reverse_Linked_List_II2
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null) return null;
            ListNode dummy = new ListNode(0); // create a dummy node to mark the head of this list
            dummy.next = head;
            ListNode pre = dummy; // make a pointer pre as a marker for the node before reversing
            for (int i = 0; i < m - 1; i++) pre = pre.next;

            ListNode start = pre.next; // a pointer to the beginning of a sub-list that will be reversed
            ListNode then = start.next; // a pointer to a node that will be reversed

            // 1 - 2 -3 - 4 - 5 ; m=2; n =4 ---> pre = 1, start = 2, then = 3
            // dummy-> 1 -> 2 -> 3 -> 4 -> 5

            for (int i = 0; i < n - m; i++)
            {
                start.next = then.next;
                then.next = pre.next;
                pre.next = then;
                then = start.next;
            }

            // first reversing : dummy->1 - 3 - 2 - 4 - 5; pre = 1, start = 2, then = 4
            // second reversing: dummy->1 - 4 - 3 - 2 - 5; pre = 1, start = 2, then = 5 (finish)

            return dummy.next;

        }
    }
    class Reverse_Linked_List_II
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n) return head;

            ListNode prev = null;//track (m-1)th node
            ListNode first = new ListNode(0);//first's next points to mth
            ListNode second = new ListNode(0);//second's next points to (n+1)th

            int i = 0;
            ListNode p = head;
            while (p != null)
            {
                i++;
                if (i == m - 1)
                {
                    prev = p;
                }

                if (i == m)
                {
                    first.next = p;
                }

                if (i == n)
                {
                    second.next = p.next;
                    p.next = null;
                }

                p = p.next;
            }
            if (first.next == null)
                return head;

            // reverse list [m, n]    
            ListNode p1 = first.next;
            ListNode p2 = p1.next;
            p1.next = second.next;

            while (p1 != null && p2 != null)
            {
                ListNode t = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = t;
            }

            //connect to previous part
            if (prev != null)
                prev.next = p1;
            else
                return p1;

            return head;
        }
    }
}
