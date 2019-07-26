using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Vertical_Order_Traversal
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
            {
                return res;
            }

            var map = new Dictionary<int, List<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            Queue<int> cols = new Queue<int>();

            q.Enqueue(root);
            cols.Enqueue(0);

            int min = 0;
            int max = 0;

            while (q.Count> 0)
            {
                TreeNode node = q.Dequeue();
                int col = cols.Dequeue();

                if (!map.ContainsKey(col))
                {
                    map[col] = new List<int>();
                }
                map[col].Add(node.val);

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                    cols.Enqueue(col - 1);
                    min = Math.Min(min, col - 1);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                    cols.Enqueue(col + 1);
                    max = Math.Max(max, col + 1);
                }
            }

            for (int i = min; i <= max; i++)
            {
                res.Add(map[i]);
            }

            return res;
        }
    }
}
