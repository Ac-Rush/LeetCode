using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Zigzag_Level_Order_Traversal
    {
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            var depth = 1;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var levelResult = new List<int>();
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var item = queue.Dequeue();
                    levelResult.Add(item.val);
                    if (item.left != null)
                    {
                        queue.Enqueue(item.left);
                    }
                    if (item.right != null)
                    {
                        queue.Enqueue(item.right);
                    }
                }
                if (depth % 2 == 0)
                {
                    levelResult.Reverse();
                }
                result.Add(levelResult);
                depth++;
            }
            return result;
        }
    }


    class Binary_Tree_Zigzag_Level_Order_Traversal_2
    {
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var ans = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            if (root == null) return ans;
            queue.Enqueue(root);
            int level = 1;
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
                if (level++ % 2 == 0)
                {
                    cur.Reverse();
                }
                ans.Add(cur);
            }
            return ans;
        }
    }
}
