using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    internal class H_Index_II
    {
        /*  case by case去分析
         *  想好left 和 right的定义
         * /
        /**
         *   case 1: citations[mid] == len-mid, then it means there are citations[mid] papers that have at least citations[mid] citations.
         *   case 2: citations[mid] > len-mid, then it means there are citations[mid] papers that have moret than citations[mid] citations, so we should continue searching in the left half
         *   case 3: citations[mid] < len-mid, we should continue searching in the right side
         *   After iteration, it is guaranteed that right+1 is the one we need to find (i.e. len-(right+1) papars have at least len-(righ+1) citations)
         */
        public int HIndex(int[] citations)
        {
            int left = 0, len = citations.Length, right = len - 1, mid;
            while (left <= right)
            {
                mid = left + (right - left)/2;
                if (citations[mid] >= (len - mid)) right = mid - 1;
                else left = mid + 1;
            }
            return len - left;
        }
    }
}
