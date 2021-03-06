﻿using System;
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
            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            else
            {
                return root;
            }
        }

    }

    class Lowest_Common_Ancestor_of_a_Binary_Search_Tree2
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val > q.val) return LowestCommonAncestor(root, q, p);
            if (root == null) return null;
            if (p.val <= root.val && q.val >= root.val) return root;
            if (q.val < root.val) return LowestCommonAncestor(root.left, p, q);
            return LowestCommonAncestor(root.right, p, q);
        }

    }
}
