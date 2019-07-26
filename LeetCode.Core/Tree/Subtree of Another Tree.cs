using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Subtree_of_Another_Tree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return Traverse(s, t);
        }

        public bool Equals(TreeNode x, TreeNode y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.val == y.val && Equals(x.left, y.left) && Equals(x.right, y.right);
        }
        public bool Traverse(TreeNode s, TreeNode t)
        {
            return s != null && (Equals(s, t) || Traverse(s.left, t) || Traverse(s.right, t));
        }

        /// <summary>
        /// Status: Wrong Answer  我把 Traverse 和Equals混到一起去了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtreeWrong(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if (s == null || t == null)
            {
                return false;
            }
            if (s.val == t.val)
            {
                return IsSubtree(s.left, t.left) && IsSubtree(s.right, t.right) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
            }
            else
            {
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
            }
        }
    }
}
