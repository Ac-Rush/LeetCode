using Leetcode.Dynamic_Programming;
using LeetCode.Core.BFS;
using System;
using Leetcode.BackTrack;
using LeetCode.Core.HashTable;
using Leetcode.SlidingWindow;

namespace LeetCode.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Permutation_in_String().CheckInclusion2("adc", "dcda");

            var s = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine($"DomainName:{s.DomainName} , HostName:{s.HostName}");
          //  var t = new Remove_Duplicate_Letters();
           // t.RemoveDuplicateLetters2("bcabc");


           // TestMetrix();
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
