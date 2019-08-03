using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Insert_into_a_Binary_Search_Tree
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            TreeNode cur = root;
            while (true)
            {
                if (cur.val <= val)
                {
                    if (cur.right != null) cur = cur.right;
                    else
                    {
                        cur.right = new TreeNode(val);
                        break;
                    }
                }
                else
                {
                    if (cur.left != null) cur = cur.left;
                    else
                    {
                        cur.left = new TreeNode(val);
                        break;
                    }
                }
            }
            return root;
        }
    }

    /// <summary>
    /// 这个可以不用看了， 太差了
    /// </summary>
    class Insert_into_a_Binary_Search_Tree_DAC
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            TreeNode cur = root;
            PreOrder(root, val);
            return root;
        }

        private void PreOrder(TreeNode cur, int val)
        {
            if (cur == null) return;
            if (cur.val <= val)
            {
                if (cur.right != null) PreOrder(cur.right, val);
                else
                {
                    cur.right = new TreeNode(val);
                }
            }
            else
            {
                if (cur.left != null) PreOrder(cur.left, val);
                else
                {
                    cur.left = new TreeNode(val);
                }
            }
        }
    }


    class Insert_into_a_Binary_Search_Tree_DAC_v2
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            if (root.val > val)
            {
                root.left = InsertIntoBST(root.left, val);
            }
            else
            {
                root.right = InsertIntoBST(root.right, val);
            }
            return root;
        }
    }
}
