using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class First_Bad_Version
    {
        bool IsBadVersion(int version)
        {
            return true;
        }
       /// <summary>
       /// my solution
       /// 
       /// </summary>
       /// <param name="n"></param>
       /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n; // 模板因该是  n+1, 但是有 int越界问题， 可以写成n,因为一定有一个badversion, 没有找到 left就是 n
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))  // 如果是bad  [left, mid） ，注意边界的定义，right 一定是bad, left是好的， left 和bad重合 就是第一个
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
    }
}
