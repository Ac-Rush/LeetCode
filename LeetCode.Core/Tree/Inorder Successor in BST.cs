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
   public class Inorder_Successor_in_BST
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
               // return; //剪枝 这是个 bug千万不能剪枝，也没法剪枝，完全是个bug， 如果return prev就不会变 ， 除非 加上 prev = null; retrun;也只能剪掉自己的右子树
            }
            Prev = root;
            InorderHelper(root.right, p);

        }

    }
}
