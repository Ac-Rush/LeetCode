﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.BinarySearch;
using Leetcode.Dynamic_Programming;
using Leetcode.Tree;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Number_of_Longest_Increasing_Subsequence.FindNumberOfLIS(new[] {4, 10, 4, 3, 8, 9});
            Console.WriteLine(a);
        }
    }
}
