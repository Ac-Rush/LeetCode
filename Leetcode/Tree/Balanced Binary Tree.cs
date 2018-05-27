using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Balanced_Binary_Tree
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return Depth(root) != -1;

        }

        public int Depth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var leftDepth = Depth(root.left);
            var rightDepth = Depth(root.right);
            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(leftDepth, rightDepth);
            }
        }
    }
}
