using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Maximum_Depth_of_N_ary_Tree
    {
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;
            var maxSub = 0;
            foreach (var n in root.children)
            {
                maxSub = Math.Max(maxSub, MaxDepth(n));
            }
            return maxSub + 1;
        }
    }
}
