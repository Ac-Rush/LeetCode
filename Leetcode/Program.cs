using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Array;
using Leetcode.BinarySearch;
using Leetcode.BinarySearch_Tree;
using Leetcode.DFS_BFS;
using Leetcode.Dynamic_Programming;
using Leetcode.HashTable;
using Leetcode.LinkList;
using Leetcode.Number;
using Leetcode.Strings;
using Leetcode.Tree;
//using Leetcode.DFS_BFS;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMatrix();
            //Delete_and_Earn.DeleteAndEarn(new[] {3, 4, 2});
            //  TestArry();
            //TestList();
            //TestString();
            // TestNum();
        }

        static void TestMatrix()
        {
            Longest_Increasing_Path_in_a_Matrix.LongestIncreasingPath(new int[,] { {9,9,4} , {6,6,8} , {2,1,1} });
        }

        static void TestNum()
        {
            //Valid_Number.IsNumberMy("2e0");
        }

        static void TestString()
        {
            Valid_Palindrome_II.ValidPalindrome("cbbcc");
        }

        static void TestList()
        {
            var root = new ListNode(4);
            root.next = new ListNode(2);
            root.next.next = new ListNode(1);
            root.next.next.next = new ListNode(3);
         //   root.next.next.next.next = new ListNode(5);
          //  root.next.next.next.next.next = new ListNode(6);
          //  root.next.next.next.next.next.next = new ListNode(7);
            Insertion_Sort_List.InsertionSortList(root);
        }

        static void TestArry()
        {
            Daily_Temperatures.DailyTemperatures(new[] {73, 74, 75, 71, 69, 72, 76, 73});
            //K_diff_Pairs_in_an_Array.FindPairs(new[] {1, 3, 1, 5, 4}, 0);
            //   Island_Perimeter.IslandPerimeter(new int[4, 4] { { 0, 1, 0, 0,  }, { 1, 1, 1 , 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 }});
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
     //       var a = Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal.BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
      //      Console.WriteLine(a);
        }
    }
}
