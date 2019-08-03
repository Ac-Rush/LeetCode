using Leetcode.Dynamic_Programming;
using System;

namespace LeetCode.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1,3,4,5,6,6,6,6,6,6,6,78};
           
            var c = Array.LastIndexOf(array, 6);
            var d = Array.IndexOf(array,6);
            Console.Read();
            // Wildcard_Matching_memo.IsMatch("mississippi", "m??*ss*?i*pi");
        }
    }
}
