using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class N_ary_Tree_Preorder_Traversal
    {
        public IList<int> Preorder(Node root)
        {
            Pre(root);
            return result;
        }

        List<int> result = new List<int>();

        private void Pre(Node root)
        {
            if (root != null)
            {
                result.Add(root.val);
                foreach (var n in root.children)
                {
                    Pre(n);
                }

            }
        }
    }
}
