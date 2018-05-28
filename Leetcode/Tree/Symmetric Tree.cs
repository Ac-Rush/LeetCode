using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class Symmetric_Tree
    {
         
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return IsMirror(root.left, root.right);
        }


        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null || right == null)
            {
                return false;
            }
            if (left.val != right.val)
            {
                return false;
            }

            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }

    }
}
