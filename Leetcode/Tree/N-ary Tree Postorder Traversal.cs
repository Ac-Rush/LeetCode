using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }

        class N_ary_Tree_Postorder_Traversal
        {
            List<int> result = new List<int>();

            public IList<int> Postorder(Node root)
            {
                Post(root);
                return result;
            }

            private void Post(Node root)
            {
                if (root != null)
                {
                    foreach (var n in root.children)
                    {
                        Post(n);
                    }

                    result.Add(root.val);
                }
            }
        }
    }
}
