using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class RandomListNode
    {
      public int label;
      public RandomListNode next, random;
      public RandomListNode(int x) { this.label = x; }
  };
    class Copy_List_with_Random_Pointer
    {
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)// my bug
            {
                return head;
            }
            var iter = head;

            // First round: make copy of each node,
            // and link them together side-by-side in a single list.
            while (iter != null)
            {
                var next = iter.next;

                RandomListNode copy = new RandomListNode(iter.label);
                iter.next = copy;
                copy.next = next;

                iter = next;
            }

            // Second round: assign random pointers for the copy nodes.
            iter = head;
            while (iter != null)
            {
                if (iter.random != null)
                {
                    iter.next.random = iter.random.next;
                }
                iter = iter.next.next;
            }
            // Third round: restore the original list, and extract the copy list.
            iter = head;
            RandomListNode pseudoHead = new RandomListNode(0);
            RandomListNode copy2, copyIter = pseudoHead;

            while (iter != null)
            {
                var next = iter.next.next;

                // extract the copy
                copy2 = iter.next;
                copyIter.next = copy2;
                copyIter = copy2;

                // restore the original list
                iter.next = next;

                iter = next;
            }

            return pseudoHead.next;

        }


        public RandomListNode CopyRandomList2(RandomListNode head)
        {
            if (head == null)// my bug
            {
                return head;
            }
            var map = new Dictionary<RandomListNode, RandomListNode>();
            // loop 1. copy all the nodes
            RandomListNode node = head;
            while (node != null)
            {
                map[node]= new RandomListNode(node.label);
                node = node.next;
            }

            // loop 2. assign next and random pointers
            node = head;
            while (node != null)
            {
                if (node.next != null)
                {
                    map[node].next = map[node.next];
                }

                if (node.random != null) map[node].random = map[node.random];
                node = node.next;
            }

            return map[head];

        }
    }
}
