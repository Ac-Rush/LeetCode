using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Postorder_Traversal
    {
        public IList<int> PostorderTraversal(TreeNode root)
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
                    path.Push(new Guide(1, current.Node));
                    path.Push(new Guide(0, current.Node.right));
                    path.Push(new Guide(0, current.Node.left));
                   
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


        public IList<int> PostorderTraversal2(TreeNode root)
        {
            LinkedList<int> result = new LinkedList<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode p = root;
            while (stack.Any() || p != null)
            {
                if (p != null)
                {
                    stack.Push(p);
                    result.AddFirst(p.val);  // Reverse the process of preorder
                    p = p.right;             // Reverse the process of preorder
                }
                else
                {
                    TreeNode node = stack.Pop();
                    p = node.left;           // Reverse the process of preorder
                }
            }
            return result.ToList();
        }


        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode p = root;
            while (stack.Any() || p != null)
            {
                if (p != null)
                {
                    stack.Push(p);
                    result.Add(p.val);  // Add before going to children
                    p = p.left;          // Reverse the process of preorder
                }
                else
                {
                    TreeNode node = stack.Pop();
                    p = node.right;           // Reverse the process of preorder
                }
            }
            return result;
        }

        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode p = root;
            while (stack.Any() || p != null)
            {
                if (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }
                else
                {
                    TreeNode node = stack.Pop();
                    result.Add(node.val);  // Add after all left children
                    p = node.right;
                }
            }
            return result;
        }
    }
}
