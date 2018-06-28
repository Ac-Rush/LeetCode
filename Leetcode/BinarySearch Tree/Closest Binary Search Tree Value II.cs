using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch_Tree
{
    /// <summary>
    /// O(N) Solution
    /// </summary>
    class Closest_Binary_Search_Tree_Value_II
    {
        /// <summary>
        /// 太综合了
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            List<int> res = new List<int>();

            Stack<int> s1 = new Stack<int>(); // predecessors //只装比target小的 等于的
            Stack<int> s2 = new Stack<int>(); // successors   //只装 比target大的， 注意边界

            inorder(root, target, false, s1);
            inorder(root, target, true, s2);

            while (k-- > 0)
            {
                if (s1.Count == 0)
                    res.Add(s2.Pop());
                else if (s2.Count == 0)
                    res.Add(s1.Pop());
                else if (Math.Abs(s1.Peek() - target) < Math.Abs(s2.Peek() - target))
                    res.Add(s1.Pop());
                else
                    res.Add(s2.Pop());
            }

            return res;
        }

        void inorder(TreeNode root, double target, bool reverse, Stack<int> stack)
        {
            if (root == null) return;

            inorder(reverse ? root.right : root.left, target, reverse, stack);
            // early terminate, no need to traverse the whole tree
            if ((reverse && root.val <= target) || (!reverse && root.val > target)) return;
            // track the value of current node
            stack.Push(root.val);
            inorder(reverse ? root.left : root.right, target, reverse, stack);
        }
    }

    /// <summary>
    /// O（NlogN）
    /// </summary>
    class Closest_Binary_Search_Tree_Value_IIC
    {
        /// <summary>
        /// 太综合了
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            List<int> ret = new List<int>();
            Stack<TreeNode> succ = new Stack<TreeNode>();
            Stack<TreeNode> pred = new Stack<TreeNode>();
            initializePredecessorStack(root, target, pred);
            initializeSuccessorStack(root, target, succ);
            if (succ.Any() && pred.Any() && succ.Peek().val == pred.Peek().val)  //
            {
                getNextPredecessor(pred);
            }
            while (k-- > 0)
            {
                if (!succ.Any())
                {
                    ret.Add(getNextPredecessor(pred));
                }
                else if (!pred.Any())
                {
                    ret.Add(getNextSuccessor(succ));
                }
                else
                {
                    double succ_diff = Math.Abs((double)succ.Peek().val - target);
                    double pred_diff = Math.Abs((double)pred.Peek().val - target);
                    if (succ_diff < pred_diff)
                    {
                        ret.Add(getNextSuccessor(succ));
                    }
                    else
                    {
                        ret.Add(getNextPredecessor(pred));
                    }
                }
            }
            return ret;
        }

        //保存前面的序列
        private void initializeSuccessorStack(TreeNode root, double target, Stack<TreeNode> succ)
        {
            while (root != null)
            {
                if (root.val == target)  //如果相同就停止  
                {
                    succ.Push(root);
                    break;
                }
                else if (root.val > target)
                {
                    succ.Push(root);
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
        }
        //保存后面的序列
        private void initializePredecessorStack(TreeNode root, double target, Stack<TreeNode> pred)
        {
            while (root != null)
            {
                if (root.val == target)
                {
                    pred.Push(root);
                    break;
                }
                else if (root.val < target)
                {
                    pred.Push(root);
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }
        }

        private int getNextSuccessor(Stack<TreeNode> succ)
        {
            TreeNode curr = succ.Pop();
            int ret = curr.val;
            curr = curr.right;
            while (curr != null)
            {
                succ.Push(curr);
                curr = curr.left;
            }
            return ret;
        }

        private int getNextPredecessor(Stack<TreeNode> pred)
        {
            TreeNode curr = pred.Pop();
            int ret = curr.val;
            curr = curr.left;
            while (curr != null)
            {
                pred.Push(curr);
                curr = curr.right;
            }
            return ret;
        }
    }
}
