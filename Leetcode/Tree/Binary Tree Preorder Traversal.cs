using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Preorder_Traversal
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {

            var result = new List<int>();
            Preorder(root, result);
            return result;
        }

        private void Preorder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.val);
            Preorder(root.left, result);
            Preorder(root.right, result);
        }
    }
}
