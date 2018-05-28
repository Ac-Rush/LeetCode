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
}
