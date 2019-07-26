using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Search_in_a_Binary_Search_Tree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
            {
                return root;
            }
            return root.val < val ? SearchBST(root.right, val) : SearchBST(root.left, val);
        }
    }
}
