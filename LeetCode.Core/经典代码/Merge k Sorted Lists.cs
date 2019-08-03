using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.Classic
{

    public class Merge_k_Sorted_Lists_02
    {

        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        ///

        /**
         * 利用坐标和 comparer使 SortedSet 支持duplicate
         */
        public class NodeIndex
        {
            public ListNode Node { get; set; }
            public int Index { get; set; }
            public NodeIndex(ListNode node, int index) { Node = node; Index = index; }
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            SortedSet<NodeIndex> ss = new SortedSet<NodeIndex>(Comparer<NodeIndex>.Create((a, b) => a.Node.val == b.Node.val ? a.Index - b.Index : a.Node.val - b.Node.val));
            ListNode head = new ListNode(int.MinValue), p = head;
            for (int i = 0; i < lists.Length; i++)
                if (lists[i] != null) ss.Add(new NodeIndex(lists[i], i));
            while (ss.Count != 0)
            {
                NodeIndex nextMerge = ss.Min;
                p.next = nextMerge.Node;
                p = p.next;
                ss.Remove(nextMerge);
                if ((nextMerge.Node = nextMerge.Node.next) != null) ss.Add(nextMerge);
            }
            return head.next;
        }


        public class NodeIndex2
        {
            // index of the array from  
            // which the element is taken 
            public int IndexCol;

            // index of the next element  
            // to be picked from array 
            public int IndexRow;
            public NodeIndex2(int indexCol, int indexRow) { IndexCol = indexCol; IndexRow = indexRow; }
        }
        public List<int> MergeKArray(int[][] lists)
        {
            var ans = new List<int>();
            SortedSet<NodeIndex2> ss = new SortedSet<NodeIndex2>(
                Comparer<NodeIndex2>.Create((a, b) =>
                lists[a.IndexRow][a.IndexCol] == lists[b.IndexRow][b.IndexCol] 
                ? a.IndexRow - b.IndexRow 
                : lists[a.IndexRow][a.IndexCol] - lists[b.IndexRow][b.IndexCol]));
            ListNode head = new ListNode(int.MinValue), p = head;
            for (int i = 0; i < lists.Length; i++)
                if (lists[i] != null && lists[i].Length > 0) ss.Add(new NodeIndex2(0, i));
            while (ss.Count != 0)
            {
                var node = ss.Min;
                ans.Add(lists[node.IndexRow][node.IndexCol]);
                node.IndexCol++;
                ss.Remove(node);
                if (node.IndexCol < lists[node.IndexRow].Length) ss.Add(node);
            }
            return ans;
        }
        
    }

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



        /*
       public static ListNode MergeKLists(ListNode[] lists)
       {
           return null;
          var queue = new BinaryHeap<ListNode>(ListNodeComparere.Instance);
           var n = lists.Length;
           for (int i = 0; i < n; i++)
               if (lists[i] != null)
                   queue.Insert(lists[i]);

           var head = new ListNode(-1);
           var prev = head;
           while (!queue.IsEmpty)
           {
               var node = queue.RemoveRoot();
               if (node.next != null)
                   queue.Insert(node.next);

               prev = prev.next = node;
           }

           return head.next;
           
    }
    */
    }


    public class Merge_k_Sorted_Lists_22
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
