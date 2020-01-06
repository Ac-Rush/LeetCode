using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/
    /// </summary>
    class Find_Largest_Value_in_Each_Tree_Row
    {
        public IList<int> LargestValues(TreeNode root)
        {
            var ans = new List<int>();
            if (root == null) return ans;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var count = queue.Count;
                var max = int.MinValue;
                while (count-- > 0)
                {
                    var node = queue.Dequeue();
                    max = Math.Max(max, node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                ans.Add(max);
            }
            return ans;
        }
    }
}
