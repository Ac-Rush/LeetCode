using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Count_Complete_Tree_Nodes
    {
        /// <summary>
        /// Time Limit Exceeded 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodesBad(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }


        public int CountNodes(TreeNode root)
        {
            int leftDepth = LeftDepth(root);
            int rightDepth = RightDepth(root);

            if (leftDepth == rightDepth)
                return (1 << leftDepth) - 1;
            else
                return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        private int RightDepth(TreeNode root)
        {
            // TODO Auto-generated method stub
            int dep = 0;
            while (root != null)
            {
                root = root.right;
                dep++;
            }
            return dep;
        }

        private int LeftDepth(TreeNode root)
        {
            // TODO Auto-generated method stub
            int dep = 0;
            while (root != null)
            {
                root = root.left;
                dep++;
            }
            return dep;
        }
    }

    class Count_Complete_Tree_Nodes2
    {
        int height(TreeNode root)
        {
            return root == null ? -1 : 1 + height(root.left);
        }
        public int countNodes(TreeNode root)
        {
            int h = height(root);
            return h < 0 ? 0 :
                height(root.right) == h - 1 ? (1 << h) + countNodes(root.right)
                : (1 << h - 1) + countNodes(root.left);
        }
    }
}
