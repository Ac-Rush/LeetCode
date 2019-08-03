using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Serialize_and_Deserialize_Binary_Tree
    {
        private static  String spliter = ",";
    private static  String NN = "X";
        // Encodes a tree to a single string.
        public string Serialize(TreeNode root)
        {
            if (root == null) return "";
            Queue<TreeNode> q = new Queue<TreeNode>();
            StringBuilder res = new StringBuilder();
            q.Enqueue(root);
            while (q.Any())
            {
                TreeNode node = q.Dequeue();
                if (node == null)
                {
                    res.Append("n ");
                    continue;
                }
                res.Append(node.val + " ");
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
            return res.ToString();
        }


        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            if (data == "") return null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            String[] values = data.Split(' ');
            TreeNode root = new TreeNode(int.Parse(values[0]));
            q.Enqueue(root);
            for (int i = 1; i < values.Length; i++)
            {
                TreeNode parent = q.Dequeue();
                if (!values[i].Equals("n"))
                {
                    TreeNode left = new TreeNode(int.Parse(values[i]));
                    parent.left = left;
                    q.Enqueue(left);
                }
                if (!values[++i].Equals("n"))
                {
                    TreeNode right = new TreeNode(int.Parse(values[i]));
                    parent.right = right;
                    q.Enqueue(right);
                }
            }
            return root;
        }
    }
}
