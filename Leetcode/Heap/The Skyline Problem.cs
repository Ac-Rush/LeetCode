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
    /// </summary>
   public class The_Skyline_Problem
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
