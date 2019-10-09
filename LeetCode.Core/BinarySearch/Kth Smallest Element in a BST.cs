using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Core.Lib.Tree;
namespace Leetcode.BinarySearch
{
    class Kth_Smallest_Element_in_a_BST
    {


        /// <summary>
        /// <see cref="Traversals"/>  InorderTraversal 同一模板
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest2(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            var cur = root;
            while (cur != null || stack.Any())
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                if (--k == 0) return cur.val;
                cur = cur.right;
            }
            return -1;
        }










        private int Kth = 0;
        private int K = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            K = k;
            InOrder(root);
            return Kth;
        }

        private void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.left);
                if (--K == 0)
                {
                    Kth = root.val;
                }
                InOrder(root.right);
            }
        }


        
    }
}
