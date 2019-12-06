using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.经典代码
{
    class Merge_k_Sorted_Arrays
    {/**
         * 利用坐标和 comparer使 SortedSet 支持duplicate
         */
        public class NodeIndex
        {
            public int Value { get; set; }
            public int ArrayIndex { get; set; }
            public int Index { get; set; }
            public NodeIndex(int value, int arrayIndex, int index) { Value = value;
                ArrayIndex = arrayIndex; Index = index; }
        }
        public int[] MergeKLists(int[][] lists)
        {
            SortedSet<NodeIndex> ss = new SortedSet<NodeIndex>(Comparer<NodeIndex>.Create((a, b) => a.Value == b.Value ? a.ArrayIndex - b.ArrayIndex : a.Value - b.Value));
            var ans = new List<int>();
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null && lists[i].Length > 0) ss.Add(new NodeIndex(lists[i][0], i, 0));
            }
               
            while (ss.Count != 0)
            {
                NodeIndex nextMerge = ss.Min;
                ans.Add(nextMerge.Value);
                nextMerge.Index++;
                ss.Remove(nextMerge);
                if (nextMerge.Index < lists[nextMerge.ArrayIndex].Length) ss.Add(nextMerge);
            }
            return ans.ToArray();
        }

    }
}
