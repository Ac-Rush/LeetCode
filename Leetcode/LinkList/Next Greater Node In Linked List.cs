using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Next_Greater_Node_In_Linked_List
    {
        public int[] NextLargerNodes(ListNode head)
        {
            var values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            var result = new int[values.Count];
            var stack = new Stack<int>();

            //递减单调栈， 用于求第一个比自己大的 
            for (var i = 0; i < values.Count; i++)
            {
                //
                while (stack.Any() && values[stack.Peek()] < values[i])
                    result[stack.Pop()] = values[i];
                stack.Push(i);
            }
            return result;

        }
    }
}
