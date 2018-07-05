﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Array;
using Leetcode.ArrayS;
using Leetcode.BackTrack;
using Leetcode.BinarySearch;
using Leetcode.BinarySearch_Tree;
using Leetcode.DAC;
using Leetcode.DFS;
using Leetcode.DFS_BFS;
using Leetcode.Dynamic_Programming;
using Leetcode.HashTable;
using Leetcode.Heap;
using Leetcode.Helper;
using Leetcode.LinkList;
using Leetcode.Matrix;
using Leetcode.Number;
using Leetcode.Sort;
using Leetcode.Strings;
using Leetcode.Tree;
using Leetcode.TwoPointer;
using Interval = Leetcode.Sort.Interval;
using Number_of_Atoms = Leetcode.Strings.Number_of_Atoms;

//using Leetcode.DFS_BFS;

namespace Leetcode
{
    


    class Program
    {

       

        static void Main(string[] args)
        {
           

          //  TestLinkedList();
          //  TestTree();
           // TestGraph();

            TestMatrix();
            //Delete_and_Earn.DeleteAndEarn(new[] {3, 4, 2});
            //  TestArry();
            //TestList();
            //TestString();
            // TestNum();
        }
        static void TestLinkedList()
        {
            var lists = new ListNode[3];
            lists[0] = new ListNode(1);
            lists[0].next = new ListNode(4);
            lists[0].next.next = new ListNode(5);

            lists[1] = new ListNode(1);
            lists[1].next = new ListNode(3);
            lists[1].next.next = new ListNode(4);

            lists[2] = new ListNode(2);
            lists[2].next = new ListNode(6);

            Merge_k_Sorted_Lists.MergeKLists(lists);
        }

        static void TestGraph()
        {
            Is_Graph_Bipartite.IsBipartite(new int[][] { new int[] {1,3}, new int[] {0,2 }, new int[] { 1, 3 }, new int[] { 0,2 } });
        }

        static void TestMatrix()
        {
            Word_Search.Exist(new char[,] {{'a'}}, "a");
            var c = new The_Skyline_Problem();
            c.GetSkyline(new int[,] {{2, 9, 10}, {3, 7, 15}, {5, 12, 12}, {15, 20, 10}, {19, 24, 8}});
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
            tree.right = new TreeNode(6);
            tree.left = new TreeNode(3);
            tree.left.left = new TreeNode(2);
            tree.left.right = new TreeNode(4);
            tree.left.left.left = new TreeNode(1);

            var c = new Inorder_Successor_in_BST();
            c.InorderSuccessor(tree , new TreeNode(1));
            // tree.left.right = new TreeNode(4);
            // tree.left.left = new TreeNode(3);
            //       var a = Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal.BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
            //      Console.WriteLine(a);
        }
    }
}
