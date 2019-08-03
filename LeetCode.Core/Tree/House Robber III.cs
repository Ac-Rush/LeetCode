using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class House_Robber_III_Tree
    {
        /// <summary>
        /// DP solution
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Rob(TreeNode root)
        {
            int[] maxVal = DpRob(root);
            return Math.Max(maxVal[0], maxVal[1]);

        }
        public int[] DpRob(TreeNode root)
        {
            if (root == null)
            {
                return new int[] { 0, 0 };
            }
            else
            {
                int[] maxVal = new int[2];//maxVal[0] store the max value without robing current node, maxVal[1] store the max value with robing current node,
                int[] leftMax = DpRob(root.left);
                int[] rightMax = DpRob(root.right);
                maxVal[0] = Math.Max(leftMax[0], leftMax[1]) + Math.Max(rightMax[0], rightMax[1]); //不偷 current
                maxVal[1] = leftMax[0] + rightMax[0] + root.val;      //偷current
                return maxVal;
            }
        }
    }
}
