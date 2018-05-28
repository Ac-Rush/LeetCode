using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Print_Binary_Tree
    {
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            var res = new List<IList<string>>();
            int height = root == null ? 1 : GetHeight(root);
            int rows = height, columns = (int)(Math.Pow(2, height) - 1);
            List<string> row = new List<string>();
            for (int i = 0; i < columns; i++) row.Add("");
            for (int i = 0; i < rows; i++) res.Add(new List<string>(row));
            PopulateRes(root, res, 0, rows, 0, columns - 1);
            return res;
        }

        public void PopulateRes(TreeNode root, List<IList<string>> res, int row, int totalRows, int i, int j)
        {
            if (row == totalRows || root == null) return;
            res[row][(i + j) / 2] = root.val.ToString();
            PopulateRes(root.left, res, row + 1, totalRows, i, (i + j) / 2 - 1);
            PopulateRes(root.right, res, row + 1, totalRows, (i + j) / 2 + 1, j);
        }

        public int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }
}
