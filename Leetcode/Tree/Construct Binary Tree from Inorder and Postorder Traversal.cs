using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public  class Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
    {
        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return helper2(0, 0, inorder.Length, postorder, inorder);
        }

        public static TreeNode helper2(int posStart, int inStart, int Length, int[] postorder, int[] inorder)
        {

            if (posStart > postorder.Length - 1 || Length <= 0)
            {
                return null;
            }
            if (Length == 1)
            {
                return new TreeNode(postorder[posStart + Length - 1]);
            }
            TreeNode root = new TreeNode(postorder[posStart + Length - 1]);
            int inIndex = 0; // Index of current root in inorder
            for (int i = inStart; i < inStart + Length; i++)
            {
                if (inorder[i] == root.val)
                {
                    inIndex = i;
                }
            }
            var leftLength = inIndex - inStart;
            root.left = helper2(posStart , inStart, leftLength, postorder, inorder);
            root.right = helper2(posStart + leftLength , inIndex + 1, Length - leftLength - 1 , postorder, inorder);
            return root;
        }
    }
}
