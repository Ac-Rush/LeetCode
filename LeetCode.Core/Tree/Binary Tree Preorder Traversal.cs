using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Preorder_Traversal
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {

            var result = new List<int>();
            Preorder(root, result);
            return result;
        }

        private void Preorder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.val);
            Preorder(root.left, result);
            Preorder(root.right, result);
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {

            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            var stack = new Stack<TreeNode>();
            
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop(); // 这个非递归是最好想的
                result.Add(node.val);
                
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return result;
        }


        public IList<int> PreorderTraversal3(TreeNode root)
        {

            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<Guide> path = new Stack<Guide>();

            path.Push(new Guide(0, root));
            while (path.Count > 0)
            {
                var current = path.Pop();
                if (current.Node == null)
                {
                    continue;   //defensive coding
                }
                if (current.Ope == 1)
                {
                    result.Add(current.Node.val);
                }
                else
                {
                    path.Push(new Guide(0, current.Node.right));
                    path.Push(new Guide(0, current.Node.left));
                    path.Push(new Guide(1, current.Node));
                }
            }
            return result;
        }

        public class Guide
        {
            public int Ope; // 0. visit; 1. print
            public TreeNode Node;

            public Guide(int ope, TreeNode node)
            {
                this.Ope = ope;
                this.Node = node;
            }
        }
    }
}
