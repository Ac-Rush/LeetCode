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
using Leetcode.DFS_BFS;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var a = Subsets_Class.Subsets(new[] {1,2,3});
=======
            var tree = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.right.left = new TreeNode(4);
           tree.right.right = new TreeNode(3);
            tree.left = new TreeNode(9);
           // tree.left.right = new TreeNode(4);
           // tree.left.left = new TreeNode(3);
            var a = Binary_Tree_Zigzag_Level_Order_Traversal.ZigzagLevelOrder(tree);
>>>>>>> 952182f9123acf916eea11baa0beebccfdc58e94
            Console.WriteLine(a);
        }
    }
}
