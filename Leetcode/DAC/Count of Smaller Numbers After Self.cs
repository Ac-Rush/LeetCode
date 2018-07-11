using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.LinkList;

namespace Leetcode.DAC
{
    class Count_of_Smaller_Numbers_After_Self
    {/// <summary>
    /// 从后向前 一个个二分查找，并插入到有序数组里，  O（N^2）
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
        public IList<int> CountSmaller(int[] nums)
        {
            var ans = new int[nums.Length];
            List<int> sorted = new List<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int index = findIndex(sorted, nums[i]);
                ans[i] = index;
                sorted.Insert(index, nums[i]);
            }
            return ans.ToList();
        }
        private int findIndex(List<int> sorted, int target)
        {
            if (sorted.Count == 0) return 0;
            int start = 0;
            int end = sorted.Count - 1;
            if (sorted[end] < target) return end + 1;
            if (sorted[start] >= target) return 0;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (sorted[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            if (sorted[start] >= target) return start;
            return end;
        }
    }

    /// <summary>
    /// What is Binary Index Tree
    /// </summary>
    /*
     1, we should build an array with the length equals to the max element of the nums array as BIT.
2, To avoid minus value in the array, we should first add the (min+1) for every elements 
(It may be out of range, where we can use long to build another array. But no such case in the test cases so far.)
3, Using standard BIT operation to solve it.

    */
    class Count_of_Smaller_Numbers_After_Self_NLogN
    {
        public List<int> CountSmaller(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }
            // find min value and minus min by each elements, plus 1 to avoid 0 element
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                min = (nums[i] < min) ? nums[i] : min;
            }
            int[] nums2 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums2[i] = nums[i] - min + 1;
                max = Math.Max(nums2[i], max);
            }
            int[] tree = new int[max + 1];
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                res.Insert(0, get(nums2[i] - 1, tree));
                update(nums2[i], tree);
            }
            return res;
        }

        private int get(int i, int[] tree)
        {
            int num = 0;
            while (i > 0)
            {
                num += tree[i];
                i -= i & (-i);
            }
            return num;
        }
        private void update(int i, int[] tree)
        {
            while (i < tree.Length)
            {
                tree[i]++;
                i += i & (-i);
            }
        }
    }


    class Count_of_Smaller_Numbers_After_Self_BST
    {
        public class Node
        {
            public Node left, right;
            public int val, sum, dup = 1;
            public Node(int v, int s)
            {
                val = v;
                sum = s;
            }
        }
        public List<int> CountSmaller(int[] nums)
        {
            var ans = new int[nums.Length];
            Node root = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                root = insert(nums[i], root, ans, i, 0);
            }
            return ans.ToList();
        }

        private Node insert(int num, Node node, int[] ans, int i, int preSum)
        {
            if (node == null)
            {
                node = new Node(num, 0);
                ans[i] = preSum;
            }
            else if (node.val == num)
            {
                node.dup++;
                ans[i] = preSum + node.sum;
            }
            else if (node.val > num)
            {
                node.sum++;
                node.left = insert(num, node.left, ans, i, preSum);
            }
            else
            {
                node.right = insert(num, node.right, ans, i, preSum + node.dup + node.sum);
            }
            return node;
        }
    }
}
