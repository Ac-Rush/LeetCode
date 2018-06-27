using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.经典代码
{
    class TreeTemplate
    {
        //inorder
        TreeNode firstElement = null;
        TreeNode secondElement = null;
        TreeNode prevElement = new TreeNode(int.MinValue);

        /// <summary>
        /// 中序遍历 记录prev
        /// </summary>
        /// <param name="root"></param>
        private void traverse(TreeNode root)
        {

            if (root == null)
                return;

            traverse(root.left);

            // Start of "do some business", 
            // If first element has not been found, assign it to prevElement (refer to 6 in the example above)
            if (firstElement == null && prevElement.val >= root.val)
            {
                firstElement = prevElement;
            }

            // If first element is found, assign the second element to the root (refer to 2 in the example above)
            if (firstElement != null && prevElement.val >= root.val)
            {
                secondElement = root;
            }
            prevElement = root;   //这个时候更新 prev

            // End of "do some business"

            traverse(root.right);
        }
    }
}
