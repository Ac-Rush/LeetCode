using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Binary_Tree_Right_Side_View
    {
        IList<int> result = new List<int>();
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null)
            {
                return result;
            }
            BFS(new List<TreeNode> {root});
            return result;
        }

        private void BFS(List<TreeNode> roots)
        {
            var nextLevel = new List<TreeNode>();
            for (int i = 0; i < roots.Count; i++)
            {
                if (i == roots.Count - 1)
                {
                    result.Add(roots[i].val);
                }

                if (roots[i].left != null)
                {
                    nextLevel.Add(roots[i].left);
                }
                if (roots[i].right != null)
                {
                    nextLevel.Add(roots[i].right);
                }
            }
            if (nextLevel.Count > 0)
            {
                BFS(nextLevel);
            }
        }


    }
}
