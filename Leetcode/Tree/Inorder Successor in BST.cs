using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
   /// <summary>
   /// my solution 中序遍历 记录 prev模板
   /// </summary>
    class Inorder_Successor_in_BST
    {
        private TreeNode Prev;
        private TreeNode result;
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            InorderHelper(root, p);
            return result;
        }

        public void InorderHelper(TreeNode root, TreeNode p)
        {
            if (root == null)
            {
                return;
            }
            InorderHelper(root.left, p );

            if (Prev != null && Prev.val == p.val)
            {
                result = root;
            }
            Prev = root;
            InorderHelper(root.right, p);

        }

    }
}
