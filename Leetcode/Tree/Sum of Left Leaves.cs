using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Sum_of_Left_Leaves
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left != null && root.left.left == null && root.left.right == null)
            {
                return root.left.val + SumOfLeftLeaves(root.right);
            }
            return SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
        }
    }
}
