using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class _559__Maximum_Depth_of_N_ary_Tree
    {

        public int MaxDepth(Node root)
        {
            if (root == null) return 0;
            var max = 1;
            foreach (var node in root.children)
            {
                max = Math.Max(max, MaxDepth(node) + 1);
            }
            return max;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }

}