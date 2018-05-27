using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Second_Minimum_Node_In_a_Binary_Tree
    {
        private static int? min;
        private static int? second;
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            FindSecondMinimumValue(root.left);
            if (min == null)
            {
                min = root.val;
            }
            else
            {
                if (root.val < min)
                {
                    second = min;
                    min = root.val;
                }
                else if (root.val > min && (second == null || (second != null && second > root.val)))
                {
                    second = root.val;
                }
            }
            FindSecondMinimumValue(root.right);
            return second ?? -1;
        }
    }
}
