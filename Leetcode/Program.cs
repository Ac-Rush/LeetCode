using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Array;
using Leetcode.BinarySearch;
using Leetcode.BinarySearch_Tree;
using Leetcode.Dynamic_Programming;
using Leetcode.Tree;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode(1);
            tree.right = new TreeNode(5);
            tree.right.left = new TreeNode(3);
            var a = Minimum_Absolute_Difference_in_BST.GetMinimumDifference2(tree);
            Console.WriteLine(a);
        }
    }
}
