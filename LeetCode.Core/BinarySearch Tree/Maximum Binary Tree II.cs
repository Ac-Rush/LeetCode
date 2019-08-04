using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.BinarySearch_Tree
{
    class Maximum_Binary_Tree_II
    {
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            if (root.val < val)
            {
                return new TreeNode(val)
                {
                    left = root
                };
            }

            root.right = InsertIntoMaxTree(root.right, val);
            return root;
        }
    }
}
