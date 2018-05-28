using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Find_Mode_in_Binary_Search_Tree
    {
        int? _prev = null;
        int _count = 1;
        int _max = 0;
        public int[] FindMode(TreeNode root)
        {
            if (root == null) return new int[0];

            List<int> list = new List<int>();
            Traverse(root, list);

            return list.ToArray();
        }
        private void Traverse(TreeNode root, List<int> list)
        {
            if (root == null) return;
            Traverse(root.left, list);
            if (_prev != null)
            {
                if (root.val == _prev)
                    _count++;
                else
                    _count = 1;
            }
            if (_count > _max)
            {
                _max = _count;
                list.Clear();
                list.Add(root.val);
            }
            else if (_count == _max)
            {
                list.Add(root.val);
            }
            _prev = root.val;
            Traverse(root.right, list);
        }
    }
}
