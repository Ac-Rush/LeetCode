using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Lowest_Common_Ancestor_of_a_Binary_Tree
    {
        /// <summary>
        /// 太厉害，太简洁
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            //  空或者有一个是 就返回root
            if (root == null || root == p || root == q) return root;
            //看左边
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            //看右边
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            // 1 不在左边 ， 返回右边
            // 2， 在左边，
            //       2.a 右边 不在，返回左边
            //       2.b 右边在， 返回root
            return left == null ? right : right == null ? left : root;
        }
    }
}
