using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/longest-univalue-path/description/
    /// </summary>
    class Longest_Univalue_Path
    {
        /// <summary>
        /// 这个太棒了
        /// 
        /// 这个递归调用两个，完全是意义的做法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null) return 0;
            int sub = Math.Max(LongestUnivaluePath(root.left), LongestUnivaluePath(root.right));  // 左右子树中的最大 路径
            return Math.Max(sub, Helper(root.left, root.val) + Helper(root.right, root.val)); // 上面的值，  还是过当前节点的那条路径
        }

        /// <summary>
        /// 这个是算单边
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        int Helper(TreeNode root, int val)//Max Length from root path where each node in the path has the same value
        {
            if (root == null || root.val != val) return 0;
            return 1 + Math.Max(Helper(root.left, val), Helper(root.right, val));
        }
        
    }


    class Longest_Univalue_Path_my
    {
        private int max;
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null) return 0;
            max = 0;
            PostOrder(root, root.val);
            return max - 1;
        }

        public int PostOrder(TreeNode root, int target)
        {
            if (root == null) return 0;
            var left = PostOrder(root.left, root.val);
            var right = PostOrder(root.right, root.val);
            if (left + right + 1 > max)
            {
                max = left + right + 1;
            }

            if (target == root.val)
            {
                return Math.Max(left, right) + 1;
            }
            return 0;
        }

    }
}
