using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.Tree
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    class N_ary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            var ans = new List<IList<int>>();
            if (root == null) return ans;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var count = queue.Count;
                var level = new List<int>();
                while (count-- > 0)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);
                    foreach (var c in node.children)
                    {
                        queue.Enqueue(c);
                    }
                }
                ans.Add(level);
            }
            return ans;
        }
    }
}
