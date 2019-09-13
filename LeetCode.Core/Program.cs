using Leetcode.Dynamic_Programming;
using LeetCode.Core.BFS;
using System;

namespace LeetCode.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMetrix();
            Console.Read();
            // Wildcard_Matching_memo.IsMatch("mississippi", "m??*ss*?i*pi");
        }
        void TestArray()
        {
            var array = new int[] { 1, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 78 };

            var c = Array.LastIndexOf(array, 6);
            var d = Array.IndexOf(array, 6);
        }

        static void TestMetrix()
        {
            var a = new As_Far_from_Land_as_Possible();
            a.MaxDistance(new int[][]{ new [] { 1,0,0}, new[] { 0, 0, 0 }, new[] { 0, 0, 0 } });
        }
    }
}
