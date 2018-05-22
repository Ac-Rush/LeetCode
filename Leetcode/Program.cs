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
            var a = Search_a_2D_Matrix.SearchMatrix(new int[,] { {1,3,5,7} , {10,11,16,20}, {23,30,34,50} }, 13);
            Console.WriteLine(a);
        }
    }
}
