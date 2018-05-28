using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch_Tree
{
    class Minimum_Distance_Between_BST_Nodes
    {
        public int MinDiffInBST(TreeNode root)
        {
            return Minimum_Absolute_Difference_in_BST.GetMinimumDifference2(root);
        }
    }
}
