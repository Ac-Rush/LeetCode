using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch_Tree
{
    /// <summary>
    ///  my solution easy
    /// </summary>
    class Closest_Binary_Search_Tree_Value
    {
        /// <summary>
        /// 模板， 保存 并更新全局变量
        /// 用DFS求解
        /// </summary>
        private int Ans;
        private double MinDiff = double.MaxValue;
        public int ClosestValue(TreeNode root, double target)
        {
            Helper(root, target);
            return Ans;
        }

        public void Helper(TreeNode root, double target)
        {
            if (root == null)
            {
                return;
            }
            var curDiff = Math.Abs(root.val - target);
            if (curDiff < MinDiff)
            {
                MinDiff = curDiff;
                Ans = root.val;
            }
            if (target < root.val)
            {
                Helper(root.left, target);
            }
            else
            {
                Helper(root.right, target);
            }
        }
    }


    class Closest_Binary_Search_Tree_Value2
    {
       /// <summary>
       /// 别人的答案
       /// 这个很不错
       /// </summary>
       /// <param name="root"></param>
       /// <param name="target"></param>
       /// <returns></returns>
        public int ClosestValue(TreeNode root, double target)
        {
            int a = root.val;
            TreeNode kid = target < a ? root.left : root.right;
            if (kid == null) return a;
            int b = ClosestValue(kid, target);
            return Math.Abs(a - target) < Math.Abs(b - target) ? a : b;
        }
    }
}
