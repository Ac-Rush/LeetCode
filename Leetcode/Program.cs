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
            var ret = findRadiusC.findRadius(new int[] {1,2,3}, new int[] {2});
            Console.WriteLine(ret);
            var a = Flipping_Image_832.FlipAndInvertImage(new int[][] { new []{1,1,0}, new int[] {1,0,1}, new int[] {0,0,0}   } );
            Console.WriteLine(a);
        }
    }
}
