using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.DAC
{
    public class Merge_k_Sorted_Lists
    {
        public class MyComparer : IComparer<ListNode>
        {
            public int Compare(ListNode a, ListNode b)
            { return a.val.CompareTo(b.val); }
        }
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var dummy = new ListNode(0);
            var tail = dummy;
            // var heap = new SortedSet<ListNode>(new MyComparer());
            var heap = new SortedSet<int>();
            var dict = new Dictionary<int, List<ListNode>>();
            foreach (var node in lists)
            {
                if (node == null) continue;
                heap.Add(node.val);
                if (!dict.ContainsKey(node.val))
                {
                    dict[node.val] = new List<ListNode>();
                }
                dict[node.val].Add(node);
            }
            while (heap.Any())
            {
                var nodeVal = heap.Min;
                var node = dict[nodeVal].First();
                dict[nodeVal].RemoveAt(0);
                if (dict[nodeVal].Count == 0)
                {
                    dict.Remove(nodeVal);
                    heap.Remove(nodeVal);

                }
                tail.next = node;
                tail = tail.next;// my bug 需要移动
                if (node.next != null)
                {
                    var nextNode = node.next;
                    heap.Add(nextNode.val);
                    if (!dict.ContainsKey(nextNode.val))
                    {
                        dict[nextNode.val] = new List<ListNode>();
                    }
                    dict[nextNode.val].Add(nextNode);
                }

            }
            return dummy.next;
        }
    }
}
