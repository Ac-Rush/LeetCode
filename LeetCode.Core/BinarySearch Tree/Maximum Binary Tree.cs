using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.BinarySearch_Tree
{
    public class TreeNode
    {
             public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }

    class Maximum_Binary_Tree_O_N
    {

        /*
         *
         Here is his brilliant solution
https://discuss.leetcode.com/topic/98454/c-9-lines-o-n-log-n-map

The key idea is:

We scan numbers from left to right, build the tree one node by one step;
We use a stack to keep some (not all) tree nodes and ensure a decreasing order; //单调栈
For each number, we keep pop the stack until empty or a bigger number; The bigger number (if exist, it will be still in stack) is current number's root, and the last popped number (if exist) is current number's left child (temporarily, this relationship may change in the future); Then we push current number into the stack.
         */
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < nums.Length; i++)
            {
                TreeNode curr = new TreeNode(nums[i]);
                while (stack.Any()&& stack.Peek().val < nums[i]) //如果碰到一个大的， 说明可以把当前当根， 左子树为 栈底
                {
                    curr.left = stack.Pop();
                }
                if (stack.Any()) //如果栈不空, 那这个peek就比当前值大
                {
                    stack.Peek().right = curr;
                }
                stack.Push(curr);
            }

            return !stack.Any() ? null : stack.Last(); // stack.Last()是返回栈底
        }
    }

    /// <summary>
    /// my bad solution  效率低
    /// </summary>
    class Maximum_Binary_Tree
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }

        public TreeNode Helper(int[] nums, int l, int r)
        {
            if (l > r) return null;
            if (l == r) return new TreeNode(nums[r]);
            var maxIndex = l;
            for (int i = l; i <= r; i++)
            {
                if (nums[i] > nums[maxIndex]) maxIndex = i;
            }
            var node = new TreeNode(nums[maxIndex]);
            node.left = Helper(nums, l, maxIndex - 1);
            node.right = Helper(nums, maxIndex + 1, r);
            return node;
        }
    }
}
