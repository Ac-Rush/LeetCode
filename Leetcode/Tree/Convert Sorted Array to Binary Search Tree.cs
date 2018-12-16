using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }

        private TreeNode Helper(int[] nums, int l, int r)
        {
            if (l > r) return null;
            var m = (l + r) / 2;
            var node = new TreeNode(nums[m]);
            node.left = Helper(nums, l, m - 1);
            node.right = Helper(nums, m + 1, r);
            return node;
        }
    }
}
