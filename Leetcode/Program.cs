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
            var a = Minimum_Size_Subarray_Sum.MinSubArrayLen(7, new int[]{ 2, 3, 1, 2, 4, 3 });
            Console.WriteLine(a);
        }
    }
}
