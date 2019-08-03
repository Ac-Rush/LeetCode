using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    public class MedianFinder2
    {
        SortedSet<Tuple<int, int>> small;
        SortedSet<Tuple<int, int>> large;
        int count = 0;
        /** initialize your data structure here. */
        public MedianFinder2()
        {
            small = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((a, b) =>
           a.Item1 == b.Item1 ? a.Item2 - b.Item2 : a.Item1 - b.Item1
     ));

            large = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((a, b) =>
                  a.Item1 == b.Item1 ? a.Item2 - b.Item2 : a.Item1 - b.Item1
            ));
        }

        public void AddNum(int num)
        {
            large.Add(new Tuple<int, int>(num, count++));  //把数加到 large
            small.Add(large.Min);  //把large里面的最小的 放到 min,
            large.Remove(large.Min);
            if (small.Count > large.Count)  //这个就保证了  small的个数 小于等于 large
            {
                large.Add(small.Max);
                small.Remove(small.Max);
            }
        }

        public double FindMedian()
        {
            if (small.Count == large.Count)
                return (double)(small.Max.Item1 + large.Min.Item1) / 2.0;
            else
                return large.Min.Item1;
        }
    }

    public class MedianFinder
    {
        SortedSet<Tuple<int, int>> small;
        SortedSet<Tuple<int, int>> large;
        private int? avg;
        int count = 0;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            small = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((a, b) =>
           a.Item1 == b.Item1 ? a.Item2 - b.Item2 : a.Item1 - b.Item1
     ));

            large = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((a, b) =>
                  a.Item1 == b.Item1 ? a.Item2 - b.Item2 : a.Item1 - b.Item1
            ));
        }

        public void AddNum(int num)
        {
            large.Add(new Tuple<int, int>(num, count++));  //把数加到 large
            small.Add(large.Min);  //把large里面的最小的 放到 min,
            large.Remove(large.Min);
            if (small.Count < large.Count)
            {
                large.Add(small.Max);
                small.Remove(small.Max);
            }
        }

        public double FindMedian()
        {
            if (small.Count == large.Count)
                return (double)(small.Max.Item1 + large.Min.Item1) / 2.0;
            else
                return large.Min.Item1;
        }
    }
}
