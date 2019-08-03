using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Line_Reflection
    {
        /// <summary>
        /// 这个不是找平均值， 找最大最小边界也可以
        /// 最左边和最右边 对称
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool IsReflected(int[,] points)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            HashSet<String> set = new HashSet<String>();
            for (int i = 0; i < points.GetLength(0); i++)
            {
                max = Math.Max(max, points[i,0]);
                min = Math.Min(min, points[i, 0]);
                String str = points[i, 0] + "a" + points[i, 1];
                set.Add(str);
            }
            int sum = max + min;
            for (int i = 0; i < points.GetLength(0); i++)
            {
                //int[] arr = {sum-p[0],p[1]};
                String str = (sum - points[i, 0]) + "a" + points[i, 1];
                if (!set.Contains(str))
                    return false;

            }
            return true;
        }
    }

    
}
