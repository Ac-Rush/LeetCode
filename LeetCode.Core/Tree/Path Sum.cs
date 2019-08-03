﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Path_Sum
    {
        private bool hasPath = false;
        public bool HasPathSum(TreeNode root, int sum)
        {
            Helper(root, sum);
            return hasPath;
        }

        private void Helper(TreeNode root, int sum)
        {
            if (root == null)
            {
                return;
            }
            if (root.left == null && root.right == null)
            {
                if (sum == root.val)
                {
                    hasPath = true;
                }
            }
            Helper(root.left, sum - root.val);
            Helper(root.right, sum - root.val);
        }


        public bool HasPathSum2(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null && root.val == sum) return true;
            return (HasPathSum2(root.left, sum - root.val) || HasPathSum2(root.right, sum - root.val));
        }
    }
}
