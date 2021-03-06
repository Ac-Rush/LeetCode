﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode;

namespace LeetCode.Core.Lib.Tree
{
    public class Traversals
    {
        /// <summary>
        /// 模板
        /// </summary>
        /// <remarks>
        /// 模板
        /// </remarks>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count > 0)// 只要cur 不是null 或是栈不空
            {
                while (cur != null) //其实比较好理解， 一直访问左支， 直到叶子
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop(); // 弹出 栈顶 
                list.Add(cur.val);  //处理
                cur = cur.right;  //cur 指向右节点
            }
            return list;
        }

        /// <summary>
        ///  先序遍历
        /// </summary>
        ////// <remarks>
        /// 模板
        /// </remarks>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {

            var result = new List<int>();
            var stack = new Stack<TreeNode>();

            stack.Push(root);
            while (stack.Any())
            {
                var node = stack.Pop(); // 这个非递归是最好想的
                if(node == null) continue;
                result.Add(node.val);

                stack.Push(node.right);
                stack.Push(node.left);
            }
            return result;
        }
    }
}
