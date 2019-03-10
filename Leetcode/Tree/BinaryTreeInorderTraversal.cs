using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    /// 94. Binary Tree Inorder Traversal
    /// https://leetcode.com/problems/binary-tree-inorder-traversal/description/
    /// </summary>
    public class BinaryTreeInorderTraversal3
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
           // Solution1(root, list);
            return list;
        }

        private void Solution1(TreeNode root, IList<int> list)
        {
            if (root == null)
            {
                return;
            }
          //  Solution1(root.left, list);
            list.Add(root.val);
          //  Solution1(root.right, list);
        }

        public List<Integer> inorderTraversal(TreeNode root)
        {
            List<Integer> list = new ArrayList<Integer>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || !stack.empty())
            {
                while (cur != null)
                {
                    stack.add(cur);
                    cur = cur.left;
                }
                cur = stack.pop();
                list.add(cur.val);
                cur = cur.right;
            }

            return list;
        }
    }

    public class BinaryTreeInorderTraversal4
    {
       
        public List<int> inorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>() ;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count >0)// 只要cur 不是null 或是栈不空
            {
                while (cur != null) //其实比较好理解， 一直访问左支， 直到叶子
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop(); // 弹出 栈顶 
                list.Add(cur.val);  //处理
                cur = cur.right;  //cur 指向右节点
            }
            return list;
        }
    }
}
