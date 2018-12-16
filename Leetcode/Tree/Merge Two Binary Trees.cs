using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Merge_Two_Binary_Trees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }
            else if (t2 == null)
            {
                return t1;
            }
            else if (t1 == null)
            {
                return t2;
            }
            else
            {
                var t = new TreeNode(t1.val + t2.val)
                {
                    left = MergeTrees(t1.left, t2.left),
                    right = MergeTrees(t1.right, t2.right)
                };
                return t;
            }
        }
    }
}
