using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Leaf_Similar_Trees
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            Stack<TreeNode> s1 = new Stack<TreeNode>(), s2 = new Stack<TreeNode>();
            s1.Push(root1); s2.Push(root2);
            while (s1.Any() && s2.Any())
                if (dfs(s1) != dfs(s2)) return false;
            return !s1.Any() && !s2.Any();
        }
        public int dfs(Stack<TreeNode> s)
        {
            while (true)
            {
                TreeNode node = s.Pop();
                if (node.right != null) s.Push(node.right);
                if (node.left != null) s.Push(node.left);
                if (node.left == null && node.right == null) return node.val;
            }
        }
    }
}
