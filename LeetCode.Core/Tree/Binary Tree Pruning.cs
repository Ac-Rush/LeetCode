using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Pruning
    {
        /// <summary>
        /// easy
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var left = PruneTree(root.left);
            var right = PruneTree(root.right);

            if (left == null && right == null && root.val == 0)
            {
                return null;
            }
            root.left = left;
            root.right = right;
            return root;
        }
    }
}
