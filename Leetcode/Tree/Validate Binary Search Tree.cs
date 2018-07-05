using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Validate_Binary_Search_Tree
    {
        public bool IsValidBST(TreeNode root)
        {
            return InRange(root, long.MinValue, long.MaxValue);
        }

        public bool InRange(TreeNode root, long low, long high)
        {
            if(root == null)
            {
                return true;
            }
            if(root.val <= low || root.val >= high)
            {
                return false;
            }

            return InRange(root.left, low, root.val  ) && InRange(root.right, root.val , high);  //这个不需要 减一加一，要不容易越界 //所以上一步需要等号
        }
    }
}
