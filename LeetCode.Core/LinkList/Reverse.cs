using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Reverse
    {
        public class Node
        {

            public int data;
            public Node next;

            Node(int d)
            {
                data = d;
                next = null;
            }
        }

        Node reverse(Node node)
        {
            Node prev = null;
            Node current = node;
            Node next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            node = prev;
            return node;
        }
    }
}
