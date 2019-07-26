using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
   /// <summary>
   /// my solution
   /// </summary>
    class Binary_Tree_Longest_Consecutive_Sequence
    {
        private int Max;
        public int LongestConsecutive(TreeNode root)
        {
            LongestConsecutiveHelper(root);
            return Max;
        }

        public int LongestConsecutiveHelper(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var curt = 1;
            if (root.left != null)
            {
                var leftCount = LongestConsecutiveHelper(root.left);
                if (root.left.val == root.val + 1)
                {
                    curt = Math.Max(curt, leftCount + 1);
                }
            }
            if (root.right != null)
            {
                var rigthCount = LongestConsecutiveHelper(root.right);
                if (root.right.val == root.val + 1)
                {
                    curt = Math.Max(curt, rigthCount + 1);
                }
            }
            Max = Math.Max(curt, Max);
            return curt;
        }
    }
}
