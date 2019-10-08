using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Core.Lib.Tree;

namespace Leetcode.Tree
{
    class Validate_Binary_Search_Tree
    {
        public bool IsValidBST(TreeNode root)
        {
            return InRange(root, long.MinValue, long.MaxValue);
        }

        public bool InRange(TreeNode root, long low, long high)
        {
            if(root == null)
            {
                return true;
            }
            if(root.val <= low || root.val >= high)
            {
                return false;
            }

            return InRange(root.left, low, root.val  ) && InRange(root.right, root.val , high);  //这个不需要 减一加一，要不容易越界 //所以上一步需要等号
        }
    }

    class Validate_Binary_Search_Tree_Inorder
    {
        TreeNode prev = null;
        bool IsBST = true;
        public bool IsValidBST(TreeNode root)
        {
            Inorder(root);
            return IsBST;

        }

        private void Inorder(TreeNode root)
        {
            if (root != null)
            {
                Inorder(root.left);
                if (prev != null && prev.val >= root.val)
                {
                    IsBST = false;
                }
                prev = root;
                Inorder(root.right);
            }
        }
    }


    /// <summary>
    /// <see cref="Traversals"/>  InorderTraversal
    /// </summary>
    class Validate_Binary_Search_Tree_Inorder_2
    {
        public bool IsValidBST(TreeNode root)
        {

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root, prev = null ;

            while (cur != null || stack.Count > 0)// 只要cur 不是null 或是栈不空
            {
                while (cur != null) //其实比较好理解， 一直访问左支， 直到叶子
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop(); // 弹出 栈顶 
                if (prev != null && prev.val >= cur.val) return false;
                prev = cur;
                cur = cur.right;  //cur 指向右节点
            }
            return true;
        }
    }
}
