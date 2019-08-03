using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Reshape_the_Matrix
    {
        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            var hight = nums.GetLength(0);
            var weight = nums.GetLength(1);
            if((hight * weight) != (r * c)){
                return nums;
            }

            var result = new int[r, c];
            for(int i = 0; i < r * c; i++)
            {
                result[i / c, i % c] = nums[i / weight, i % weight];
            }
            return result;
        }
    }
}
