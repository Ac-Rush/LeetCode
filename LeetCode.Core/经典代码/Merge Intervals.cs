using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    using System;
    using System.ComponentModel;

    /// <summary>
    ///  这个和 meeting room II 相似
    /// </summary>
    public class Merge_Intervals
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static IList<Interval> Merge(IList<Interval> intervals)
        {
            var orderIntervals = intervals.OrderBy(item => item.start).ToArray(); //my bug intervals.OrderBy 不改变原数组顺序
            var result = new List<Interval>();
            for (int i = 0; i < orderIntervals.Length;)
            {
                var end = orderIntervals[i].end;
                int j = i +1;
                while (j < orderIntervals.Length && end >= orderIntervals[j].start)
                {
                    end =Math.Max(end, orderIntervals[j++].end) ; //my bug end 需要保持最大
                }
                result.Add(new Interval(orderIntervals[i].start, end));
                i = j;
            }
            return result;
        }

        public int[][] Merge(int[][] intervals)
        {
            var ans = new List<int[]>();
            if (intervals == null || intervals.Length == 0) return intervals;
            Array.Sort<int[]>(intervals, (x, y) => x[0] -y[0]); // 这样排序二维数组 真好用
            int start = intervals[0][0], end = intervals[0][1]; 
            for (int i = 1; i < intervals.Length; i++)
            {
                if (end >= intervals[i][0])
                {
                    end = Math.Max(end,intervals[i][1]); // my bug 需要 math.Max
                }
                else
                {
                    ans.Add(new int[] { start, end });
                    start = intervals[i][0];
                    end = intervals[i][1];
                }
            }
            ans.Add(new int[] { start, end });
            return ans.ToArray();
        }
    }


    //扫描线算法
    public class Merge_Intervals_2
    {

        /*
         *  扫描线解法模板
         *  
         * 
         
     start  end       
       |_____|  |_________|
           |_______|   |______|

  
  start|   |    |      |  
  end        |     |      |    |

    */
        public static IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1)
            {
                return intervals;
            }
            intervals = intervals.OrderBy(item => item.start).ToList();
            var start = intervals[0].start;
            var end = intervals[0].end;
            var result = new List<Interval>();
            foreach (var interval in intervals)
            {
                if (interval.start <= end)  //如果当前的start <= end 说明还是连续，
                {
                    end = Math.Max(end, interval.end);  //更新end
                }
                else   //否则说明不连续， 
                {
                    result.Add(new Interval(start, end));  //加入结果
                    end = interval.end;      //更新 end, start 
                    start = interval.start;
                }
            }
            return result;
        }
    }
}
