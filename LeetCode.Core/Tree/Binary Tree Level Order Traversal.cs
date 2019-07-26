using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Level_Order_Traversal
    {
        /// <summary>
        /// 太复杂， 反面教材
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            var currentLine = new List<int>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item == null)
                {
                    result.Add(new List<int>(currentLine));
                    if (queue.Count > 0)
                    {
                        currentLine.Clear();
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    currentLine.Add(item.val);
                    if (item.left != null)
                    {
                        queue.Enqueue(item.left);
                    }
                    if (item.right != null)
                    {
                        queue.Enqueue(item.right);
                    }
                }
            }
            return result;
        }
    }


    class Binary_Tree_Level_Order_Traversal2
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var ans = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            if (root == null) return ans;
            queue.Enqueue(root);
            while (queue.Any())
            {
                var count = queue.Count;
                var cur = new List<int>();
                while (count-- > 0)
                {
                    var node = queue.Dequeue();
                    cur.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                ans.Add(cur);
            }
            return ans;
        }
    }
}
