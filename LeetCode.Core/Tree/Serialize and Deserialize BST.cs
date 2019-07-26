using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    class Serialize_and_Deserialize_BST
    {
        private static  String SEP = ",";
    private static  String NULL = "null";
    // Encodes a tree to a single string.
    public String serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            if (root == null) return NULL;
            //traverse it recursively if you want to, I am doing it iteratively here
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);
            while (st.Count > 0)
            {
                root = st.Pop();
                sb.Append(root.val).Append(SEP);
                if (root.right != null) st.Push(root.right);
                if (root.left != null) st.Push(root.left);
            }
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        // pre-order traversal
        public TreeNode deserialize(String data)
        {
            if (data.Equals(NULL)) return null;
            String[] strs = data.Split(',');
            Queue<int> q = new Queue<int>();
            foreach (String e in strs)
            {
                q.Enqueue(int.Parse(e));
            }
            return getNode(q);
        }

        // some notes:
        //   5
        //  3 6
        // 2   7
        private TreeNode getNode(Queue<int> q)
        { //q: 5,3,2,6,7
            if (q.Count == 0) return null;
            TreeNode root = new TreeNode(q.Dequeue());//root (5)
            Queue<int> samllerQueue = new Queue<int>();
            while (q.Count > 0 && q.Peek() < root.val)
            {
                samllerQueue.Enqueue(q.Dequeue());
            }
            //smallerQueue : 3,2   storing elements smaller than 5 (root)
            root.left = getNode(samllerQueue);
            //q: 6,7   storing elements bigger than 5 (root)
            root.right = getNode(q);
            return root;
        }
    }
}
