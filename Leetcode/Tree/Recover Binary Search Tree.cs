using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Recover_Binary_Search_Tree
    {
        TreeNode firstElement = null;
        TreeNode secondElement = null;
        TreeNode prevElement = new TreeNode(int.MinValue);
        public void RecoverTree(TreeNode root)
        {
            // In order traversal to find the two elements
            traverse(root);

            // Swap the values of the two nodes
            int temp = firstElement.val;
            firstElement.val = secondElement.val;
            secondElement.val = temp;
        }

        /// <summary>
        /// 找到这两个点
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
            prevElement = root;

            // End of "do some business"

            traverse(root.right);
        }


        /// <summary>
        /// 中序模板
        /// </summary>
        /// <param name="root"></param>
        private void traverseTemplate(TreeNode root)
        {
            if (root == null)
                return;
            traverseTemplate(root.left);
            // Do some business
            traverseTemplate(root.right);
        }
    }
}
