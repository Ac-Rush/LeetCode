using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Unique_Binary_Search_Trees_II
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0) return new List<TreeNode>();
            return genTrees(1, n);
        }

       

    public List<TreeNode> genTrees(int start, int end)
    {

        List<TreeNode> list = new List<TreeNode>();

        if (start > end)
        {
            list.Add(null);
            return list;
        }

        if (start == end)
        {
            list.Add(new TreeNode(start));
            return list;
        }
        List<TreeNode> left, right;
        for (int i = start; i <= end; i++)
        {
            left = genTrees(start, i - 1);
            right = genTrees(i + 1, end);
            foreach (TreeNode lnode in left)
            {
                foreach (TreeNode rnode in right)
                {
                    TreeNode root = new TreeNode(i);
                    root.left = lnode;
                    root.right = rnode;
                    list.Add(root);
                }
            }
        }
        return list;
    }
}
}
