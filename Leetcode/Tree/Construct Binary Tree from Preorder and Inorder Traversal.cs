using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
    {
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            
            //return helper(0, 0, inorder.Length - 1, preorder, inorder);
            return helper2(0, 0, inorder.Length, preorder, inorder);
        }

        public TreeNode helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preStart > preorder.Length - 1 || inStart > inEnd)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[preStart]);
            int inIndex = 0; // Index of current root in inorder
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == root.val)
                {
                    inIndex = i;
                }
            }
            root.left = helper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            root.right = helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);
            return root;
        }

        public static TreeNode helper2(int preStart, int inStart, int Length, int[] preorder, int[] inorder)
        {
            
            if (preStart > preorder.Length - 1 || Length <= 0)
            {
                return null;
            }
            if(Length == 1)
            {
                return new TreeNode(preorder[preStart]);
            }
            TreeNode root = new TreeNode(preorder[preStart]);
            int inIndex = 0; // Index of current root in inorder
            for (int i = inStart; i < inStart + Length; i++)
            {
                if (inorder[i] == root.val)
                {
                    inIndex = i;
                }
            }
            root.left = helper2(preStart + 1, inStart, inIndex - inStart , preorder, inorder);
            root.right = helper2(preStart + inIndex - inStart + 1, inIndex + 1, Length - inIndex -1 + inStart, preorder, inorder);
            return root;
        }
    }
}
