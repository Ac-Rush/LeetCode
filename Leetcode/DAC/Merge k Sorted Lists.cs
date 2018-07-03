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
        
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var dummy = new ListNode(0); //dummy head;
            var tail = dummy; 
            var heap = new SortedSet<int>();    //  SortedSet +Dictionary 来模拟 PQ
            var dict = new Dictionary<int, List<ListNode>>();
            foreach (var node in lists)   // 将节点装入 PQ
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


    public class Merge_k_Sorted_Lists_2
    {

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var dummy = new ListNode(0); //dummy head;
            var tail = dummy;
            var heap = new SortedSet<int>();    //  SortedSet +Dictionary 来模拟 PQ
            var dict = new Dictionary<int, List<ListNode>>();
            foreach (var node in lists)   // 将节点装入 PQ
            {
                if (node == null) continue;
                AddToPQ(heap, node, dict);
            }
            while (heap.Any())
            {
                var node = RemoveMin(heap, dict);  //取出，并删除最小的
                tail.next = node;
                tail = tail.next;// my bug 需要移动
                if (node.next != null)
                {
                    AddToPQ(heap, node.next, dict);  // 如果最小的 的 next不空，则装入PQ
                }

            }
            return dummy.next;
        }

        private static ListNode RemoveMin(SortedSet<int> heap, Dictionary<int, List<ListNode>> dict)
        {
            var nodeVal = heap.Min;
            var node = dict[nodeVal].First();
            dict[nodeVal].RemoveAt(0);
            if (dict[nodeVal].Count == 0)
            {
                dict.Remove(nodeVal);
                heap.Remove(nodeVal);
            }
            return node;
        }

        private static void AddToPQ(SortedSet<int> heap, ListNode node, Dictionary<int, List<ListNode>> dict)
        {
            heap.Add(node.val);
            if (!dict.ContainsKey(node.val))
            {
                dict[node.val] = new List<ListNode>();
            }
            dict[node.val].Add(node);
        }
    }
}
