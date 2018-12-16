using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Level_Order_Traversal
    {
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
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var currentLine = new List<int>();
                var count = queue.Count;
                while (count-- > 0)
                {
                    var item = queue.Dequeue();
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
                result.Add(new List<int>(currentLine));
            }
            return result;
        }
    }
}
