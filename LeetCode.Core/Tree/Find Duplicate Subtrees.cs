using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /// <summary>
    /// design key  的问题
    /// </summary>
    class Find_Duplicate_Subtrees
    {
        Dictionary<string, int> count = new Dictionary<string, int>();
        List<TreeNode> ans = new List<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            Collect(root);
            return ans;
        }
        public String Collect(TreeNode node)
        {
            if (node == null) return "#";
            var serial = node.val + "," + Collect(node.left) + "," + Collect(node.right);
            if (!count.ContainsKey(serial))
            {
                count[serial] = 0;
            }
            count[serial]++;
            if (count[serial] == 2)
                ans.Add(node);
            return serial;
        }
    }
}
