using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Insert_into_a_Cyclic_Sorted_List
    {
        public class Node
        {
            public int val;
            public Node next;

            public Node(int _val, Node _next)
            {
                val = _val;
                next = _next;
            }
        }

        public Node insert(Node head, int insertVal)
        {
            //If head is null, return a new node
            if (head == null)
            {
                Node node = new Node(insertVal, null);
                node.next = node;
                return node;
            }

            Node pre = head;
            Node next = head.next;

            while (next != null)
            {
                if (pre.val <= insertVal && next.val >= insertVal //pre.val >= insertVal >= next.val    例如2>4   -> 2->3->4
                   || next.val >= insertVal && pre.val >= next.val      //例如  4->1   4 ->0->1
                   // There is no node.val smaller than the insertVal && pre is the tail
                   || pre.val <= insertVal && pre.val >= next.val      //例如  4->1  4->5->1
                  // There is no node.val greater than the insertVal && pre is the tail
                  )
                {
                    Node node = new Node(insertVal, null);
                    pre.next = node;
                    node.next = next;
                    break;
                }
                pre = next;
                next = next.next;
            }

            return head;
        }
    }
}
