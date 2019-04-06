using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Odd_Even_Linked_List
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            var dummyOdd = new ListNode(0);
            var dummyEven = new ListNode(0);
            var oddHead = dummyOdd;
            var evenHead = dummyEven;
            var count = 1;
            while (head != null)
            {
                if (count % 2 == 0)
                {
                    dummyEven.next = head;
                    dummyEven = head;
                }
                else
                {
                    dummyOdd.next = head;
                    dummyOdd = head;
                }
                head = head.next;
                count++;
            }
            dummyOdd.next = evenHead.next;
            dummyEven.next = null;
            return oddHead.next;
        }



        public ListNode oddEvenList(ListNode head)
        {
            if (head == null) return null;
            ListNode odd = head, even = head.next, evenHead = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}
