using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Path_Sum_III
    {
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return pathSumFrom(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }

        /// <summary>
        /// 从根节点开始的path的个数
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private int pathSumFrom(TreeNode node, int sum)
        {
            if (node == null) return 0;
            return (node.val == sum ? 1 : 0) // 注意这个的优先级， 需要带括号
                + pathSumFrom(node.left, sum - node.val) + pathSumFrom(node.right, sum - node.val);
        }
    }
}
