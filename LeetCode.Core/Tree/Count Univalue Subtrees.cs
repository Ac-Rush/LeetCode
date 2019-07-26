using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class Count_Univalue_Subtrees
    {
        /// <summary>
        /// my solution
        /// </summary>
        private int count = 0;
        public int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null) return 0;
            Helper(root, root.val);
            return count;

        }

        private bool Helper(TreeNode node, int value)
        {
            if (node == null)
            {
                return true;
            }
            var left = Helper(node.left, node.val);
            var right =  Helper(node.right, node.val);
            bool isUnivalSubtrees = left && right;
            // my bug ， 不能这样写，这样写 right就走不到了   bool isUnivalSubtrees = Helper(node.left, node.val) && Helper(node.right, node.val);
            if (isUnivalSubtrees) count++;
            return node.val == value && isUnivalSubtrees;
        }
    }
}
