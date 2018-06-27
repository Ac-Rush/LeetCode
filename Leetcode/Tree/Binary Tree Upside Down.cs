using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Upside_Down
    {
        /// <summary>
        /// 递归的空间复杂度 都是 (O(logn) space) 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            if (root == null || root.left == null)
            {
                return root;
            }

            TreeNode newRoot = UpsideDownBinaryTree(root.left);
            root.left.left = root.right;   // node 2 left children
            root.left.right = root;         // node 2 right children
            root.left = null;
            root.right = null;
            return newRoot;
        }

        public TreeNode UpsideDownBinaryTree2(TreeNode root)
        {
            TreeNode curr = root;
            TreeNode next = null;
            TreeNode temp = null;
            TreeNode prev = null;

            while (curr != null)
            {
                next = curr.left;

                // swapping nodes now, need temp to keep the previous right child
                curr.left = temp;
                temp = curr.right;
                curr.right = prev;

                prev = curr;
                curr = next;
            }
            return prev;
        }
    }
}
