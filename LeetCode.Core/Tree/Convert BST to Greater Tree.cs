using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    ///
    /// </summary>
    class Convert_BST_to_Greater_Tree
    {
        private int sum = 0;
        /// <summary>
        /// 解法太巧妙， 右|中|左。 正好反序
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root != null)
            {
                ConvertBST(root.right);
                sum += root.val;
                root.val = sum;
                ConvertBST(root.left);
            }
            return root;
        }
    }
}
