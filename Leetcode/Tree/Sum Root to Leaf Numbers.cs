using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Sum_Root_to_Leaf_Numbers
    {
        private int result = 0;
        public int SumNumbers(TreeNode root)
        {
            Preorder(root, 0);
            return result;
        }

        public void Preorder(TreeNode root, int sum)
        {
            if (root == null)
            {
                return;
            }
            var newSum = sum*10 + root.val;
            if (root.left == null && root.right == null)
            {
                result += newSum;
            }
            else
            {
                Preorder(root.left, newSum);
                Preorder(root.right, newSum);
            }

        }
    }
}
