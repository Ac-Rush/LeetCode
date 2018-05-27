using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }
            if (p.val > q.val)
            {
                var t = p;
                p = q;
                q = t;
            }
            if (root.val >= p.val && root.val <= q.val)
            {
                return root;
            }
            if (root.val > q.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else
            {
                return LowestCommonAncestor(root.right, p ,q );
            }
        }

    }
}
