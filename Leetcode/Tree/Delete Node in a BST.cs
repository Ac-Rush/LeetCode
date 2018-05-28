using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Delete_Node_in_a_BST
    {
        /// <summary>
        /// 交换右树最小的值，
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }
            if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }

                TreeNode minNode = findMin(root.right);
                root.val = minNode.val;  //good solution
                root.right = DeleteNode(root.right, root.val);
            }
            return root;
        }

        private TreeNode findMin(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }
    }
}
