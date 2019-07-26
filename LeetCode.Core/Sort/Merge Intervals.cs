using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    using System;
    public class Interval
    {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
     public Interval(int s, int e) { start = s; end = e; }
  }
    /// <summary>
    ///  这个和 meeting room II 相似
    /// </summary>
   public class Merge_IntervalsC
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
    }


    //扫描线算法
    public class Merge_Intervals_2C
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
            result.Add(new Interval(start, end));  //bug 需要处理最后的情况
            return result;
        }


        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0) return intervals;
            intervals = intervals.OrderBy(it => it[0]).ToArray();
            int start = intervals[0][0], end = intervals[0][1];
            var ans = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                if (end < intervals[i][0])
                {
                    ans.Add(new int[] { start, end });
                    start = intervals[i][0];
                    end = intervals[i][1];
                }
                else
                {
                    end = Math.Max(end, intervals[i][1]);
                }
            }
            ans.Add(new int[] { start, end });
            return ans.ToArray();
        }
    }
}
