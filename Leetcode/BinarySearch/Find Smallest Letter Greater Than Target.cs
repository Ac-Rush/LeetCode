using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Find_Smallest_Letter_Greater_Than_Target
    {
        //经典
        /// <summary>
        /// 左闭右开的经典二分搜索模板
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            //hi starts at 'n' rather than the usual 'n - 1'. 
            //It is because the terminal condition is 'lo < hi' and if hi starts from 'n - 1', 
            //we can never consider value at index 'n - 1'
            int low = 0, high = letters.Length;  //这个超赞high = A.Length 而不是 high = A.Length -1, 这是因为 low 不能等high， 所以不会越界， 这样可以找到第一个大的，如果不存在就返回 length.
            while (low < high)
            {
                int mid = low + ((high - low) >> 1);
                if (letters[mid] > target)
                {
                    //should not be mid-1 when A[mid]==target.
                    //could be mid even if A[mid]>target because mid<high.
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            //Because lo can end up pointing to index 'n', in which case we return the first element
            return letters[low % letters.Length];
        }
    }
}
