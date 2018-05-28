using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Maximum_Width_of_Binary_Tree
    {
        int ans;
        private int result;
        Dictionary<int, int> left = new Dictionary<int, int>();
        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Queue<int> count = new Queue<int>();
            queue.Enqueue(root);
            count.Enqueue(0);
            int max = 1;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int left = 0;
                int right = 0;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    int index = count.Dequeue();
                    if (i == 0) left = index;
                    if (i == size - 1) right = index;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        count.Enqueue(index * 2);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        count.Enqueue(index * 2 + 1);
                    }
                }
                max = Math.Max(max, right - left + 1);
            }
            return max;
        }

        /// <summary>
        /// so goode
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int WidthOfBinaryTree2(TreeNode root)
        {
            List<int> lefts = new List<int>(); // left most nodes at each level;
            return dfs(root, 1, 0, lefts);
        }
        private int dfs(TreeNode n, int id, int d, List<int> lefts)
        { // d : depth
            if (n == null) return 0;
            if (d >= lefts.Count) lefts.Add(id);   // add left most node
            return Math.Max(id + 1 - lefts[d], Math.Max(dfs(n.left, id * 2, d + 1, lefts), dfs(n.right, id * 2 + 1, d + 1, lefts)));
        }
        private void BFS(List<TreeNode> roots)
        {
            result = Math.Max( roots.Count,result);
            var nextLevel = new List<TreeNode>();

            foreach (TreeNode t in roots)
            {
                if (t == null)
                {
                    nextLevel.Add(null);
                    nextLevel.Add(null);
                }
                else
                {
                    nextLevel.Add(t.left);
                    nextLevel.Add(t.right);
                }
            }
            for (int i = nextLevel.Count -1; i >= 0; i--)
            {
                if (nextLevel[i] != null)
                {
                    break;
                }
                if (nextLevel[i] == null)
                {
                    nextLevel.RemoveAt(i);
                }
            }
            for (int i = 0; i < nextLevel.Count; i++)
            {
                if (nextLevel[i] != null)
                {
                    break;
                }
                if (nextLevel[i] == null)
                {
                    nextLevel.RemoveAt(i);
                }
            }
            if (nextLevel.Count > 0)
            {
                BFS(nextLevel);
            }
        }
    }
}
