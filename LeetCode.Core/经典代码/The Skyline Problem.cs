using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Helper;

namespace Leetcode.Heap
{
    /// <summary>
    /// https://leetcode.com/problems/the-skyline-problem/description/
    /// 
    /// 如何分析：
    /// 1. 画图，找规律，如何得出结果？
    ///     a. 如果是楼的起点， 如果是最高的输入结果
    ///     b. 如果是楼的终点， 如果是最高的，输出第二高的
    /// 
    /// 2. 怎么表示  [index, height] 表示一个楼的点
    ///     a. 起点 height 用负值来区分（这里也是排序的地方用到了）
    /// 
    /// 3. coner case。排序
    ///     a. 三种重叠方式的分析
    ///         1) 同一起点，应该是高度高的 排在 矮的前面， 要不然结果里面不对
    ///         2) 同一重点， 矮的在高的前面，    
    ///         3) 重点起点重合，先看下一个的起点   
    ///        以上三条，推出了上一步 2的表示方法，起点的height用负数表示
    /// 
    /// 4. c# 没有PQ, 用SortedSet + dictionary<key,count> 表示，因为SortedSet 不支持重复。
    /// 
    /// 5. 为什么需要用 PQ,因为要找第二大，去掉最大，加入后求最大， 是一个 HEAP问题。
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class The_Skyline_Problem2
    {
        /// <summary>
        /// [Li, Ri, Hi]
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<int[]> GetSkylineMy(int[,] buildings)
        {
            var pointers = new List<BuildPoint>();
            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                pointers.Add(new BuildPoint(buildings[i,0] , buildings[i, 2], true));
                pointers.Add(new BuildPoint(buildings[i, 1], buildings[i, 2], false));
            }
            pointers.Sort();
            var ret = new List<int[]>();
            var set = new SortedDictionary<int,int>();
            set.Add(0,1);
            foreach (var pointer in pointers)
            {
                var curtMax = set.Last().Key;
                if (pointer.IsStart)
                {
                    if (!set.ContainsKey(-pointer.Height))
                    {
                        set[-pointer.Height] = 0;
                    }
                    set[-pointer.Height]++;
                    if (curtMax < set.Last().Key)
                    {
                        ret.Add(new[] {pointer.Index, -pointer.Height});
                    }
                }
                else
                {
                    if (set[pointer.Height]-- <= 1)
                    {
                        set.Remove(pointer.Height);
                    }
                    //set.Remove(pointer.Height);
                    if (curtMax > set.Last().Key)
                    {
                        ret.Add(new[] { pointer.Index, set.Last().Key });
                    }
                }
            }
            return ret;
        }

        public IList<int[]> GetSkyline(int[,] buildings)
        {
            var height = new List<int[]>();
            var result = new List<int[]>();
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                height.Add(new int[] { buildings[i, 0], -buildings[i, 2] });
                height.Add(new int[] { buildings[i, 1], buildings[i, 2] });
            }
            height.Sort((a, b) => {
                if (a[0] != b[0])
                {
                    return a[0].CompareTo(b[0]);
                }
                return a[1].CompareTo(b[1]);
            });
            var ss = new SortedSet<int>();
            ss.Add(0);
            var pre = 0;
            foreach (var h in height)
            {
                if (h[1] < 0)
                {
                    if (!dic.ContainsKey(-h[1]))
                    {
                        dic.Add(-h[1], 0);
                    }
                    ss.Add(-h[1]);
                    dic[-h[1]]++;
                }
                else
                {
                    dic[h[1]]--;
                    if (dic[h[1]] <= 0)
                    {
                        ss.Remove(h[1]);
                    }
                }
                int cur = ss.Max;
                if (pre != cur)
                {
                    result.Add(new int[] { h[0], cur });
                    pre = cur;
                }
            }
            return result;
        }

        private class BuildPoint : IComparable<BuildPoint>
        {
            public BuildPoint(int index, int heigth, bool isStart)
            {
                Index = index;
                IsStart = isStart;

                if (isStart)
                {
                    Height = -heigth;
                }
                else
                {
                    Height = heigth;
                }
            }
            public int Index;
            public int Height;
            public bool IsStart;

            public int CompareTo(BuildPoint other)
            {
                if (Index == other.Index)
                {
                    return Height.CompareTo(other.Height);
                }
                return Index.CompareTo(other.Index);
            }
        }
    }

    
}
