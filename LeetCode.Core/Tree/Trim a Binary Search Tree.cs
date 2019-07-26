using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Trim_a_Binary_Search_Tree
    {
        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null) return null;
            if (root.val < L) return TrimBST(root.right, L, R);
            if (root.val > R) return TrimBST(root.left, L, R);
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }
    }
}
