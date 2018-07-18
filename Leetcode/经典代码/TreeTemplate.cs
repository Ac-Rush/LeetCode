using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.经典代码
{
    class TreeTemplate
    {
        //inorder
        TreeNode firstElement = null;
        TreeNode secondElement = null;
        TreeNode prevElement = new TreeNode(int.MinValue);

        /// <summary>
        /// 中序遍历 记录prev
        /// </summary>
        /// <param name="root"></param>
        private void traverse(TreeNode root)
        {

            if (root == null)
                return;

            traverse(root.left);

            // Start of "do some business", 
            // If first element has not been found, assign it to prevElement (refer to 6 in the example above)
            if (firstElement == null && prevElement.val >= root.val)
            {
                firstElement = prevElement;
            }

            // If first element is found, assign the second element to the root (refer to 2 in the example above)
            if (firstElement != null && prevElement.val >= root.val)
            {
                secondElement = root;
            }
            prevElement = root;   //这个时候更新 prev

            // End of "do some business"

            traverse(root.right);
        }
    }
    class TreeTemplate2
    {
        // 重要 模板思路 压入的不是数值而是操作
        public IList<int> PreorderTraversal(TreeNode root)
        {

            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<Guide> path = new Stack<Guide>();

            path.Push(new Guide(0, root));
            while (path.Count > 0)
            {
                var current = path.Pop();
                if (current.Node == null)
                {
                    continue;   //defensive coding
                }
                if (current.Ope == 1)
                {
                    result.Add(current.Node.val);
                }
                else
                {
                    path.Push(new Guide(0, current.Node.right));
                    path.Push(new Guide(0, current.Node.left));
                    path.Push(new Guide(1, current.Node));
                }
            }
            return result;
        }

        public class Guide
        {
            public int Ope; // 0. visit; 1. print
            public TreeNode Node;

            public Guide(int ope, TreeNode node)
            {
                this.Ope = ope;
                this.Node = node;
            }
        }
    }

}
