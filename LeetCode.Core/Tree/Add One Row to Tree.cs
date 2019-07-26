using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Add_One_Row_to_Tree
    {
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                var newRoot = new TreeNode(v);
                newRoot.left = root;
                return newRoot;
            }
            AddOneRowHelper(root, v, d, 1);
            return root;
        }
        public void AddOneRowHelper(TreeNode root, int v, int d, int curt)
        {
            if (root == null)
            {
                return;
            }
            if (d == curt + 1)
            {
                var newLeft = new TreeNode(v);
                newLeft.left = root.left;
                root.left = newLeft;

                var newRight = new TreeNode(v);
                newRight.right = root.right;
                root.right = newRight;
            }

            AddOneRowHelper(root.left, v, d, curt + 1);
            AddOneRowHelper(root.right, v, d, curt + 1);
        }

    }
}
