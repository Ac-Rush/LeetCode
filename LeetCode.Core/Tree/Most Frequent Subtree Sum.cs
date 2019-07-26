using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class Most_Frequent_Subtree_Sum
    {
        static Dictionary<int, int> sumToCount = new Dictionary<int, int>();
        static int _maxCount;
        public static int[] FindFrequentTreeSum(TreeNode root)
        {
            FindAllSum(root);
            return sumToCount.Keys.Where(key => sumToCount[key] == _maxCount).ToArray();
        }

        public static int FindAllSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var left = FindAllSum(root.left);
            var right = FindAllSum(root.right);

            var sum = root.val + left + right;
            if (!sumToCount.ContainsKey(sum))
            {
                sumToCount[sum] = 0;
            }
            _maxCount = Math.Max(_maxCount, ++sumToCount[sum]);
            return sum;
        }
    }
}
