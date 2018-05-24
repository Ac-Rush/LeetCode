using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Array;
using Leetcode.BinarySearch;
using Leetcode.Dynamic_Programming;
using Leetcode.Tree;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Find_K_Closest_Elements.FindClosestElements(new int[]{ 1, 2, 3, 3, 6, 6, 7, 7, 9, 9 }, 8, 8);
            Console.WriteLine(a);
        }
    }
}
