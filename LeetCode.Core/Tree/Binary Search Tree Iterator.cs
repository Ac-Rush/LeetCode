using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class BSTIterator
    {
        private Stack<TreeNode> stack;
        public BSTIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return  stack.Count > 0;
        }

        /** @return the next smallest number */
        public int Next()
        {
            var current = stack.Pop();
            var result = current.val;
            if (current.right != null)
            {
                var root = current.right;
                 
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
            }

            return result;
        }
    }
}
