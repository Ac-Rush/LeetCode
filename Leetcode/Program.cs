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
            TestArry();
        }


        static void TestArry()
        {
           // var a = Max_Area_of_Island.MaxAreaOfIsland(new int[4, 5] { { 1,1,0,0,0}, { 1,1,0,0,0}, { 0,0,0,1,1}, { 0, 0, 0, 1, 1 } });
            //    Console.WriteLine(a);
        }

        static void TestTree()
        {
            var tree = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.right.left = new TreeNode(4);
            tree.right.right = new TreeNode(3);
            tree.left = new TreeNode(9);
            // tree.left.right = new TreeNode(4);
            // tree.left.left = new TreeNode(3);
            var a = Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal.BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
            Console.WriteLine(a);
        }
    }
}
