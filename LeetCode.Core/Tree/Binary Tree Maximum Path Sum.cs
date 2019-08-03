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
    class Binary_Tree_Maximum_Path_Sum
    {
        // 用全局max 保存结果
        private int max = int.MinValue;  // nearly my bug was 0 
        
        public int MaxPathSum(TreeNode root)
        {
            Helper(root);
            return max;
        }

        /// <summary>
        /// post order 解决方案
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int Helper(TreeNode node)
        {
            if (node == null) return 0;
            int left = Math.Max(0, Helper(node.left));
            int right = Math.Max(0, Helper(node.right));
            max = Math.Max(max, left + right + node.val);
            return Math.Max(left, right) + node.val;
        }
    }
}
