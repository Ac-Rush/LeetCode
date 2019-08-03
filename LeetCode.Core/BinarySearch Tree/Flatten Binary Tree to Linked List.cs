using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch_Tree
{
    public class Flatten_Binary_Tree_to_Linked_List
    {
        public static void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

          
            var right = root.right;
            Flatten(right);
            if (root.left != null)
            {
                var left = root.left;
                root.right = left;
                Flatten(left);
                while (left.right != null)
                {
                    left = left.right;
                }
                left.right = right;
                root.left = null; // my bug , miss 了这句
            }
        }
    }
}
