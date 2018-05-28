using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Construct_String_from_Binary_Tree
    {
        public string Tree2str(TreeNode t)
        {
            if (t == null)
                return "";
            if (t.left == null && t.right == null)
                return t.val + "";
            if (t.right == null)
                return t.val + "(" + Tree2str(t.left) + ")";
            return t.val + "(" + Tree2str(t.left) + ")(" + Tree2str(t.right) + ")";
        }
    }
}
