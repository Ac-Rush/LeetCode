using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Level_Order_Traversal_II
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
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
            result.Reverse(0, result.Count);
            return result;
        }
    }
}
