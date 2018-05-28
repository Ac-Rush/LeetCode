using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Flatten_Binary_Tree_to_Linked_List
    {
        public void Flatten(TreeNode root)
        {
            if(root == null)
            {
                return;
            }
            var list = new List<TreeNode>();
            Preorder(root, list);
            TreeNode pre = null;
            foreach (var node in list)
            {
                node.left = null;
                node.right = null;
                if(pre != null)
                {
                    pre.right = node;
                }
                pre = node;
            }
        }

        public void Preorder(TreeNode root, List<TreeNode> list)
        {
            if (root == null)
            {
                return;
            }
            list.Add(root);
            Preorder(root.left, list);
            Preorder(root.right, list);
        }


        TreeNode prev = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void flatten(TreeNode root)
        {
            if (root == null)
                return;
            if (prev != null)
            {
                prev.left = null; //set left to null, as we do not need left nodes
                prev.right = root;
            }
            TreeNode temp = root.right; //right will be changed in next recursive calls
            prev = root;
            Flatten(root.left);
            Flatten(temp);
        }
    }
}
