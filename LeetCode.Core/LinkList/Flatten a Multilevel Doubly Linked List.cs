using Leetcode.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Flatten_a_Multilevel_Doubly_Linked_List
    {
        public class Node
        {
            public int Value { get; set; }
            public Node next { get; set; }
            public Node child { get; set; }
            public Node prev { get; set; }

            public Node(int val)
            {
                Value = val;
            }
        }
        public Node Flatten(Node head)
        {
            if (head == null) return head;
            var demyHead = head;
            var next = head.next;

            if (head.child != null)
            {
                var child = Flatten(head.child);
                head.child = null;
                head.next = child;
                child.prev = head;
                while (head.next != null)
                {
                    head = head.next;
                }
            }
            if (next != null)
            {
                next = Flatten(next);
                head.next = next;
                next.prev = head;
            }
            return demyHead;
        }
    }
}
