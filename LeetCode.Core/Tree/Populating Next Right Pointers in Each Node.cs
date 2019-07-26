using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
  
        class Populating_Next_Right_Pointers_in_Each_Node
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node()
            {
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        /// <summary>
        /// ref = Populating_Next_Right_Pointers_in_Each_Node_II 通解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                Node prev = null;
                while (count-- > 0)
                {

                    var item = queue.Dequeue();
                    if (item == null) continue;
                    if (prev != null)
                    {
                        prev.next = item;
                    }
                    prev = item;
                    queue.Enqueue(item.left);
                    queue.Enqueue(item.right);
                }
            }
            return root;
        }


        public Node Connect2(Node root)
        {
            if (root == null) return root;
            Node pre = root;
            Node cur = null;
            while (pre.left!=null)
            {
                cur = pre;
                while (cur != null)
                {
                    cur.left.next = cur.right;
                    if (cur.next != null) cur.right.next = cur.next.left;
                    cur = cur.next;
                }
                pre = pre.left;
            }
          
            return root;
        }
    }
}
