using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>
    /// my solution  //二叉树问题
    /// </summary>
    public class RangeTreeNode
    {
        public RangeTreeNode(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Start;
        public int End;
        public RangeTreeNode Left;
        public RangeTreeNode Right;

    }
    class MyCalendar
    {
        public RangeTreeNode root;
        public MyCalendar()
        {

        }

        public bool Book(int start, int end)
        {
            return AddNode(root, start, end);
        }

        private bool AddNode(RangeTreeNode node,int start, int end)
        {
            if (node == null)
            {
                root = new RangeTreeNode(start, end);
                return true;
            }
            if (node.End <= start)
            {
                if (node.Right == null)
                {
                    node.Right = new RangeTreeNode(start, end);
                    return true;
                }
                else
                {
                    return AddNode(node.Right, start, end);
                }
            }else if (node.Start >= end)
            {
                if (node.Left == null)
                {
                    node.Left = new RangeTreeNode(start, end);
                    return true;
                }
                else
                {
                    return AddNode(node.Left, start, end);
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
