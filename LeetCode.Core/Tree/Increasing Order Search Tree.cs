using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Increasing_Order_Search_Tree
    {

        /*
         *
         *
         *Straigh forward idea:
res = inorder(root.left) + root + inorder(root.right)

Several tips here:

I pass a tail part to the function, so it can link it to the last node.
This operation takes O(1), instead of O(N).
Otherwise the whole time complexity will be O(N^2).

Also, remember to set root.left = null.
Otherwise it will be TLE for Leetcode to traverse your tree.

Should arrange the old tree, not create a new tree.
The judgement won't take it as wrong answer, but it is.
         *
         *
         *
         */
        public TreeNode IncreasingBST(TreeNode root)
        {
            return increasingBST(root, null);
        }

        public TreeNode increasingBST(TreeNode root, TreeNode tail)
        {
            if (root == null) return tail;

            //拆成两半， 左子树到 根节点拉链
            TreeNode res = increasingBST(root.left, root);
            root.left = null;
            //第二部分， 右子树 和上面传入的 尾部拉链
            root.right = increasingBST(root.right, tail);
            return res;
        }
    }
}
