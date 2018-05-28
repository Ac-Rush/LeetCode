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
            var tree = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.right.left = new TreeNode(4);
           tree.right.right = new TreeNode(3);
            tree.left = new TreeNode(9);
           // tree.left.right = new TreeNode(4);
           // tree.left.left = new TreeNode(3);
            var a = Binary_Tree_Zigzag_Level_Order_Traversal.ZigzagLevelOrder(tree);
            Console.WriteLine(a);
        }
    }
}
