using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int val)
        {
            Value = val;
        }
    }
    public class MyLinkedList
    {
      

        private Node dummyRoot;
        private int size;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            dummyRoot = new Node(-1);
        }

        /** Get the value of the index-th node in the linked list. 
         * If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;

            int i = -1;
            var iterate = dummyRoot;
            Node current = null;
            while (i <= index && iterate != null) // index = 0
            {
                current = iterate;
                iterate = iterate.Next;
                i++;
            }

            return i == index + 1 ? current.Value : -1;
        }

        /** Add a node of value val before the first element of the linked list. 
         * After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            if (dummyRoot.Next == null)
            {
                dummyRoot.Next = new Node(val);
            }
            else
            {
                var tmp = dummyRoot.Next;
                dummyRoot.Next = new Node(val);
                dummyRoot.Next.Next = tmp;
            }

            size++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node iterate = dummyRoot;
            Node current = dummyRoot;

            while (iterate != null)
            {
                current = iterate;
                iterate = iterate.Next;
            }

            current.Next = new Node(val);
            size++;
        }

        /** 
         * Add a node of value val before the index-th node in the linked list. 
         * If index equals to the length of linked list, the node will be appended 
         * to the end of linked list. If index is greater than the length, the node 
         * will not be inserted. 
         */
        public void AddAtIndex(int index, int val)
        {
            Node iterate = dummyRoot;
            Node current = dummyRoot;
            int i = -1;
            while (iterate != null && i < index) // index = 0
            {
                current = iterate;
                iterate = iterate.Next;
                i++;
            }

            if (i == index)
            {
                current.Next = new Node(val);
                current.Next.Next = iterate;
            }
            size++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index) // 0 
        {
            Node iterate = dummyRoot;
            Node current = dummyRoot;
            int i = -1;
            while (iterate != null && i < index) // index = 0
            {
                current = iterate;
                iterate = iterate.Next;
                i++;
            }

            if (i == index)
            {
                current.Next = iterate == null ? null : iterate.Next;
            }
        }
    }

}
