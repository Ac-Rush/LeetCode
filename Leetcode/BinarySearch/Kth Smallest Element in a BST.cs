using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Kth_Smallest_Element_in_a_BST
    {
        private int Kth = 0;
        private int K = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            K = k;
            PreOrder(root);
            return Kth;
        }

        private void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                PreOrder(root.left);
                if (--K == 0)
                {
                    Kth = root.val;
                }
                PreOrder(root.right);
            }
        }
    }
}
