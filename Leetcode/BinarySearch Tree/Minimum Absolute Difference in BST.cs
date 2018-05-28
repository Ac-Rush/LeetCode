using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch_Tree
{
    class Minimum_Absolute_Difference_in_BST
    {
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
            {
                return int.MaxValue;
            }
            var minL = int.MaxValue;
            var minR = int.MaxValue;
            var cur = root.val;
            if (root.left != null)
            {
                minL = Math.Min(GetMinimumDifference(root.left), Math.Abs(cur - GetLargest(root.left)));
            }
            if (root.right != null)
            {
                minR = Math.Min(GetMinimumDifference(root.right), Math.Abs(cur - GetSmallest(root.right)));
            }
            return Math.Min(minL, minR);
        }

        public int GetSmallest(TreeNode root)
        {
            if (root.left == null)
            {
                return root.val;
            }
            return GetSmallest(root.left);
        }

        public int GetLargest(TreeNode root)
        {
            if (root.right == null)
            {
                return root.val;
            }
            return GetLargest(root.right);
        }


        static int min = int.MaxValue;
        static int? prev = null;

       /// <summary>
       /// inorder 里面找 prev , prev 就是离当前值最接近的
       /// </summary>
       /// <param name="root"></param>
       /// <returns></returns>
        public static int GetMinimumDifference2(TreeNode root)
        {
            if (root == null) return min;

            GetMinimumDifference2(root.left);

            if (prev != null)
            {
                min = Math.Min(min,  root.val - prev.Value);
            }
            prev = root.val;

            GetMinimumDifference2(root.right);

            return min;
        }
    }
}
