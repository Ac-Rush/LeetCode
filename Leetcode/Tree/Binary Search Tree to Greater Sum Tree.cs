using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Search_Tree_to_Greater_Sum_Tree
    {
        /// <summary>
        /// 中序遍历， 先右 后左 
        /// </summary>
        int pre = 0;
        public TreeNode BstToGst(TreeNode root)
        {
            if (root.right != null) BstToGst(root.right);
            pre = root.val = pre + root.val;
            if (root.left != null) BstToGst(root.left);
            return root;
        }
    }
}
