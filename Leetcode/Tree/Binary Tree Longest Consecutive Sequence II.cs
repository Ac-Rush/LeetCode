using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    ///  这其实是我的思路， 但是 代码没人家写得好
    /// </summary>
    class Binary_Tree_Longest_Consecutive_Sequence_II
    {
        private int max = 0;  //my bug was 1 ， 如果是空就不对
        public int LongestConsecutive(TreeNode root)
        {
            longestPath(root);
            return max;
        }

        public int[] longestPath(TreeNode root)
        {
            if (root == null)
                return new int[] { 0, 0 };
            int inr = 1, dcr = 1;
            if (root.left != null)
            {
                int[] l = longestPath(root.left);
                if (root.val == root.left.val + 1)
                    dcr = l[1] + 1;
                else if (root.val == root.left.val - 1)
                    inr = l[0] + 1;
            }
            if (root.right != null)
            {
                int[] r = longestPath(root.right);
                if (root.val == root.right.val + 1)
                    dcr = Math.Max(dcr, r[1] + 1);
                else if (root.val == root.right.val - 1)
                    inr = Math.Max(inr, r[0] + 1);
            }
            max = Math.Max(max, dcr + inr - 1);
            return new int[] { inr, dcr };
        }
    }
}
