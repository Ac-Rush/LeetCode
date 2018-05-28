using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Two_Sum_IV___Input_is_a_BST
    {
        /// <summary>
        /// Using HashSet[Accepted]
        /// </summary>
        HashSet<int>  nums = new HashSet<int>();
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null)
            {
                return false;
            }
            if (nums.Contains(k - root.val))
            {
                return true;
            }
            nums.Add(root.val);
            return FindTarget(root.left, k) || FindTarget(root.right, k);
        }

        /// <summary>
        /// Using BFS and HashSet [Accepted]
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget2(TreeNode root, int k)
        {
            var set = new HashSet<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                if (queue.Peek() != null)
                {
                    TreeNode node = queue.Dequeue();
                    if (set.Contains(k - node.val))
                        return true;
                    set.Add(node.val);
                    queue.Enqueue(node.right);
                    queue.Enqueue(node.left);
                }
                else
                    queue.Dequeue();
            }
            return false;
        }

        /// <summary>
        ///  Using BST [Accepted]
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget3(TreeNode root, int k)
        {
            var list = new List<int>();
            inorder(root, list);
            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int sum = list[l] + list[r];
                if (sum == k)
                    return true;
                if (sum < k)
                    l++;
                else
                    r--;
            }
            return false;
        }

        public void inorder(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            inorder(root.left, list);
            list.Add(root.val);
            inorder(root.right, list);
        }

    }
}
